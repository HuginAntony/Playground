using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;

namespace ReSharperDemo.Extensions
{
    public static class Converters
    {
        public static T To<T>(this object obj)
        {
            try
            {
                return (T)obj;
            }
            catch
            {
                return default(T);
            }

        }

        public static string ToXml<T>(this T objectToSerialize)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            var stringWriter = new StringWriter();
            var xmlWriter = new XmlTextWriter(stringWriter) { Formatting = Formatting.Indented };

            xmlSerializer.Serialize(xmlWriter, objectToSerialize);

            return stringWriter.ToString();
        }

        public static T CloneTo<TFrom, T>(this TFrom thisObject)
        {
            var serializer = new DataContractJsonSerializer(typeof(TFrom));
            var deserializer = new DataContractJsonSerializer(typeof(T));

            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, thisObject);
                ms.Position = 0;

                return (T)deserializer.ReadObject(ms);
            }
        }


        /// <summary>
        /// This will return the date in this format 2014-11-28
        /// </summary>
        /// <param name="date">Date to format</param>
        /// <returns>Date formatted as year-month-day</returns>
        public static string YearMonthDay(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        public static string WithMilliSeconds(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss.ffff");
        }

        public static string HourMinuteSecond(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static DateTime ToDate(this string date)
        {
            return DateTime.Parse(date);
        }
    }
}