using Microsoft.VisualBasic.CompilerServices;
using RabbitMQ.Client.Impl;

namespace RabbitMQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            RabbitMqFactory rabbitMqFactory = new RabbitMqFactory();

            for (int i = 0; i < 20; i++)
            {
                var m = new Movie
                {
                    Name = "Movie " + i,
                    Year = 2000 + i
                };

                rabbitMqFactory.SendMessage(m, m.GetType().Name);
            }

            for (int i = 0; i < 20; i++)
            {
                var m = new Game
                {
                    Name = "Game " + i,
                    Year = 2000 + i,
                    Platform = "XBox"
                };

                rabbitMqFactory.SendMessage(m, m.GetType().Name);
            }

            for (int i = 0; i < 20; i++)
            {
                var m = new Music
                {
                    ArtistName = "Artist " + i,
                    Year = 2000 + i,
                    SongName = "Song " + i
                };

                rabbitMqFactory.SendMessage(m, m.GetType().Name);
            }

            for (int i = 0; i < 20; i++)
            {
                var m = new Series
                {
                    Name = "Series " + i,
                    Year = 2000 + i,
                    NoOfSeasons = i
                };

                rabbitMqFactory.SendMessage(m, m.GetType().Name);
            }
        }
    }
}