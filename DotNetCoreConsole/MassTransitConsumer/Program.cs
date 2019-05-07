using System;
using DotNetCoreConsole;
using MassTransit;

namespace MassTransitConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                sbc.ReceiveEndpoint(host, "test_queue", ep =>
                {
                    ep.Handler<CreateAccount>(context =>
                    {
                        return Console.Out.WriteLineAsync($"[CREATEACCOUNT {DateTime.Now.ToString("s")}] Name: {context.Message.Name}, Email: {context.Message.Email}");
                    });
                });
            });

            bus.Start();

            // let the bus running and quits when user press Enter on the terminal
            Console.Write("Press any key to quit...");
            Console.ReadLine();

            // stops the bus and ends the connection to RabbitMQ
            bus.Stop();
        }
    }
}
