using AwesomeApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(Startup))]
namespace AwesomeApi
{
    public class Startup : IWebJobsStartup
    {
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPeopleRepository, PeopleRepository>();
        }

        public void Configure(IWebJobsBuilder builder)
        {
            ConfigureServices(builder.Services);
        }
    }
}
