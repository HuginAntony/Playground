using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using ETL.DataAccess;
using ETL.Service.QuartzJobs;
using log4net;
using log4net.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;
using Quartz.Simpl;
using Quartz.Spi;

namespace ETL.Service
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var logRespository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRespository, new FileInfo("log4net.config"));

            var isService = !(Debugger.IsAttached || ((IList)args).Contains("--console"));

            if (isService)
            {
                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                var pathToContentRoot = Path.GetDirectoryName(pathToExe);
                Directory.SetCurrentDirectory(pathToContentRoot);
            }

            var hostBuilder = new HostBuilder()
                              .UseContentRoot(Directory.GetCurrentDirectory())
                              .ConfigureAppConfiguration((hostingContext, config) => { })
                              .ConfigureAppConfiguration((hostContext, configApp) =>
                              {
                                  configApp.AddJsonFile("appsettings.json", true);
                              })
                              .ConfigureServices((hostContext, services) =>
                              {
                                  services.AddQuartzHostedService(hostContext.Configuration);
                                  services.AddSingleton<ReadFromQueueJob, ReadFromQueueJob>();

                                  services.AddDbContext<JadeDWContext>(options =>
                                      options.UseSqlServer(hostContext.Configuration.GetConnectionString("JadeDWConnection")));


                                  services.AddHostedService<EtlService>();
                              });

            if (isService)
                await hostBuilder.RunAsServiceAsync();
            else
                await hostBuilder.RunConsoleAsync();

        }
    }
}
