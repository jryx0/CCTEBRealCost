using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CCTEB.Real.Cost.Repository
{
    public class EFLogProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new EFSqliteLogProvider();
        }

        public void Dispose()
        {

        }

        private class EFSqliteLogProvider : ILogger
        {
            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }
            
            
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                File.AppendAllText(@".\log.txt", formatter(state, exception));
                Console.WriteLine(formatter(state, exception));
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }
            
            
        }
    }


    public static class DbContextExtensions
    {
        public static void EFLog(this DbContext context)
        {
            var serviceProvider = context.GetInfrastructure<IServiceProvider>();
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            //loggerFactory.AddProvider(new EFLogProvider());
            loggerFactory.AddDebug(); //(text, logLevel) => logLevel >= LogLevel.Trace

            //var log = loggerFactory.CreateLogger("CCTEB.Real.Cost");

           // log.LogDebug("[{0}][CCTEB.Real.Cost]EF.Core.Sqlite Logging...\r\n", System.DateTime.Now.ToLongTimeString());
        }
    }
}
