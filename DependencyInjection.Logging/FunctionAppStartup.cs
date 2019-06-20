using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

[assembly: FunctionsStartup(typeof(DependencyInjection.Scopes.FunctionAppStartup))]

namespace DependencyInjection.Scopes
{
    public class FunctionAppStartup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.RollingFile(@"d:\logs\functionapp.log")
                .CreateLogger();

            builder.Services.AddLogging(b =>
            {
                b.AddSerilog(dispose: true);
            });
        }
    }
}
