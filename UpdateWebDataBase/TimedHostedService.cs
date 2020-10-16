using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UpdateWebDataBase
{
    /// <summary>
    /// Runs ervy minute to check and see if the database has been updated with a new reading. 
    /// If the database was updated, it fetches the new reading from the database, 
    /// and sends it up to PHTresources.com
    /// </summary>
    class TimedHostedService : IHostedService, IDisposable
    {
        private readonly DbAccess _access;
        private readonly ILogger<TimedHostedService> _logger;
        private Timer _timer;
        private static DateTime checker;
        private static int counter = 0;

        public TimedHostedService(ILogger<TimedHostedService> logger, DbAccess access)
        {
            _logger = logger;
            _access = access;
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service is up and Flying");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }
        /// <summary>
        /// This is where the application starts to do its task every minute
        /// </summary>
        /// <param name="state"></param>
        private  void DoWork(object state)
        {
            ConvertData convert = new ConvertData();

            var forConversion = _access.GetReading();
            if(forConversion.Date != checker)
            {
                checker = forConversion.Date;
                var result = convert.ConvertToWebFormat(forConversion);

                var x = WebAccess.SendToApiAsync(result);
                _logger.LogInformation($"\nThe result of the API call is {x.Result}\n");
                counter = 0;
            }
            else
            {
                counter++;
                _logger.LogInformation($"Try number: {counter} waiting one minute minute...");
            }

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
