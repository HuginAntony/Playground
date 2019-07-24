using System;
using MassTransit;

namespace DotNetCoreConsole
{
    class Program
    {
        //Publish messages to RabbitMQ with MassTransit
        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });

            bus.Start();

            bus.Publish(new CreateAccount {Name = "Hugin", Email = "mass@tdsit.com"});
            
        }
    }
}
