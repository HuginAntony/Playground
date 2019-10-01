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

                rabbitMqFactory.SendMessage(m, "SBV");
            }
        }
    }
}