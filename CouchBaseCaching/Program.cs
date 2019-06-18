using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Couchbase;
using Couchbase.Authentication;
using Couchbase.Configuration.Client;
using Couchbase.Core;
using log4net;
using log4net.Config;
using WorldWideImporters;
using WWI;

namespace CouchBaseCaching
{
    class Program
    {
        private static ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static Cluster Cluster;
        private static IBucket _bucket;
        private static ImportersModel db = new ImportersModel();

        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            ClusterHelper.Initialize(
                new ClientConfiguration
                {
                    Servers = new List<Uri> { new Uri("http://localhost:8091") },
                },
                new PasswordAuthenticator("app", "123456"));

            _bucket = ClusterHelper.GetBucket("Games");

            CreateGamesCatalogue();

            var cities = db.Cities.ToList();

            //ReadRecordsFromSQL(cities);


            //Add to cache with expiry
            //InsertRecordsIntoCacheWithExpiry(cities);

            //Takes 8 seconds to insert 37940 records
            //InsertRecordsIntoCache(cities);

            //Takes 15 seconds to read 37940 records
            //ReadRecords(cities);

            //Takes 5 minutes and 47 seconds to Insert a record and immediately read the record
            //InsertAndReadRecords(cities);

            //ReadAllRecordsFromCache();
            Console.Read();
        }

        private static void CreateGamesCatalogue()
        {
            var files = Directory.GetFiles(@"F:\My Code\Game Thumbnails\jpgs");

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var game = new Game();
                game.Id = Guid.NewGuid();
                game.Name = fileInfo.Name.Replace(fileInfo.Extension,"");
                game.ImageUrl = "/images/"+fileInfo.Name;
                game.Year = 2000;


                var document = new Document<Game>
                {
                    Id = game.Id.ToString(),
                    Content = game
                };
                var upsert = _bucket.Upsert(document);

                Console.WriteLine(upsert.Success);
            }
        }

        private static void ReadRecordsFromSQL(List<City> cities)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var city in cities)
            {
                //Read records
                var thisCity = db.Cities.SingleOrDefault(c => c.CityID == city.CityID);
                var msg = string.Format("{0} {1}!", thisCity.CityID, thisCity.CityName);

                Console.WriteLine(msg);
            }

            stopwatch.Stop();
            Console.WriteLine("Time take to read {0} records from the SQL {1}", cities.Count, stopwatch.Elapsed);
        }

        private static void ReadAllRecordsFromCache()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            const string query = "SELECT cityID, cityName, latestRecordedPopulation, stateProvinceID, validFrom, validTo FROM `my`";

            var cities = _bucket.Query<City>(query).Rows;

            foreach (var city in cities)
            {
                //Read records
                var msg = string.Format("{0} {1}!", city.CityID, city.CityName);

                Console.WriteLine(msg);
            }

            stopwatch.Stop();
            Console.WriteLine("Time take to read {0} records from the SQL {1}", cities.Count, stopwatch.Elapsed);
        }

        private static void InsertAndReadRecords(List<City> cities)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var city in cities)
            {
                var document = new Document<City>
                {
                    Id = city.CityID + city.CityName,
                    Content = city
                };
                var upsert = _bucket.Upsert(document);

                if (upsert.Success)
                {
                    var get = _bucket.GetDocument<City>(document.Id);
                    var item = get.Content;
                    var msg = string.Format("{0} {1}!", document.Id, item.CityName);

                    Console.WriteLine(msg);

                    //var cityInfo = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                    //_log.Info(new { message = "Loading city from CouchBase cache", city = cityInfo });
                }
                else
                {
                    //_log.Error(new
                    //{
                    //    message = "Failed to store document into CouchBase cache.",
                    //    error = upsert.Message,
                    //    exception = upsert.Exception
                    //});
                }
            }

            stopwatch.Stop();
            Console.WriteLine("Time take to insert data into the cache and read it from the cache {0} minutes {1} seconds", stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds);
        }

        private static void InsertRecordsIntoCache(List<City> cities)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var city in cities)
            {
                var document = new Document<City>
                {
                    Id = city.CityID + city.CityName,
                    Content = city
                };

                var upsert = _bucket.Upsert(city.CityID + city.CityName, city);
            }

            stopwatch.Stop();
            Console.WriteLine("Time take to insert {0} records into the cache {1}", cities.Count, stopwatch.Elapsed);
        }

        private static void InsertRecordsIntoCacheWithExpiry(List<City> cities)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var city in cities)
            {
                var upsert = _bucket.Upsert("Expire" + city.CityID + city.CityName, city, new TimeSpan(0, 0, 0, 30));
                //_log.Info(new { message = "Adding city to CouchBase cache", city = city.CityName, expiry = new TimeSpan(0, 0, 0, 30) });
            }

            stopwatch.Stop();
            Console.WriteLine("Time take to insert {0} records into the cache {1}", cities.Count, stopwatch.Elapsed);
        }


        private static void ReadRecords(List<City> cities)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var city in cities)
            {
                //Read records
                var get = _bucket.GetDocument<City>(city.CityID + city.CityName);
                var item = get.Content;
                var msg = string.Format("{0} {1}!", get.Id, item.CityName);

                //var cityInfo = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                //_log.Info(new { message = "Loading city from CouchBase cache", city = cityInfo });
                Console.WriteLine(msg);
            }

            stopwatch.Stop();
            Console.WriteLine("Time take to read {0} records from the cache {1}", cities.Count, stopwatch.Elapsed);
        }

        public void GetFromCache()
        {
            var thisCity = _bucket.GetDocument<City>("Hugin");

            if (!thisCity.Success)
            {
                var ins = _bucket.Upsert(new Document<City>
                {
                    Id = "1" + "Hugin",
                    Content = new City { CityName = "Hugin" }
                });
            }
            var cityData = thisCity.Content;
        }

        private static void InsertRecordsIntoCacheCustomers(List<City> cities)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var city in cities)
            {
                var document = new Document<City>
                {
                    Id = city.CityID + city.CityName,
                    Content = city
                };

                var upsert = _bucket.Upsert(document);
            }

            stopwatch.Stop();
            Console.WriteLine("Time take to insert {0} records into the cache {1}", cities.Count, stopwatch.Elapsed);
        }
    }
}
