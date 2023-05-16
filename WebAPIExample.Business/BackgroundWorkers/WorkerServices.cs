using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPIExample.Business.BackgroundWorkers
{
    public static class WorkerServices
    {
        public static void AddBackgroundWorkerServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHostedService<BackgroundWorker1>();
        }
    }
}