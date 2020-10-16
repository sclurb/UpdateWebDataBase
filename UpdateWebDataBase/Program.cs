using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using UpdateWebDatabase.Data;

namespace UpdateWebDataBase
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var hostBuilder = new HostBuilder()
                .ConfigureAppConfiguration((hostContext, configBuilder) =>
                {
                    configBuilder.SetBasePath(Directory.GetCurrentDirectory());
                    configBuilder.AddJsonFile("appsettings.json", optional: true);
                    configBuilder.AddJsonFile(
                        $"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json",
                        optional: true);
                    configBuilder.AddEnvironmentVariables();
                })
                .ConfigureLogging((hostContext, configLogging) =>
                {
                    configLogging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
                    configLogging.AddFilter("Microsoft", LogLevel.Warning);
                    configLogging.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
                    configLogging.AddConsole();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<LocalDbContext>(options =>
                    options.UseSqlServer("Data Source=.\\SQLSERVERFORIIS; AttachDbFilename=Z:\\Web\\App_Data\\Original.mdf; " +
                "Integrated Security=false; User = fred; password = Chainsaw1; MultipleActiveResultSets=True;"));
                    services.AddScoped<LocalDbContext>();
                    services.AddScoped<DbAccess>();
                    services.AddScoped<IHostedService, TimedHostedService>();
                });
            await hostBuilder.RunConsoleAsync();


        }
    }
}
