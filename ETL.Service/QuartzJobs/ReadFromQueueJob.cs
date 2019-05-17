using System;
using System.Threading.Tasks;
using Quartz;

namespace ETL.Service.QuartzJobs
{
    public class ReadFromQueueJob : IJob
    {

        public ReadFromQueueJob()
        {
        }

        Task IJob.Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Job started");
            return Task.CompletedTask;
        }
    }
}
