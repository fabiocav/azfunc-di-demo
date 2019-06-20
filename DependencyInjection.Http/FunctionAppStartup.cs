using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Polly;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

[assembly: FunctionsStartup(typeof(DependencyInjection.Http.FunctionAppStartup))]

namespace DependencyInjection.Http
{
    public class FunctionAppStartup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            // Basic HTTP client factory usage
            builder.Services.AddHttpClient();

            // Named HTTP Client
            builder.Services.AddHttpClient("githubapi", c =>
            {
                // Set the base address
                c.BaseAddress = new Uri("https://api.github.com/");

                // Set default headers for the client
                c.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/vnd.github.v3+json");
                c.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "AzureFunctions-HttpClient-Sample");
            }).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)));
        } 
    }
}
