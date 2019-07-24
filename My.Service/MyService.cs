using System;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using Microsoft.Extensions.Hosting;

namespace My.Service
{
    public class MyService : IHostedService, IDisposable
    {
        private Timer _timer;

        private readonly ILog _log = LogManager.GetLogger(typeof(MyService));

        public MyService()
        {
            
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Timed Background Service is starting.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _log.Info("Doing work");
            Console.WriteLine("Timed Background Service is working.");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Timed Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}