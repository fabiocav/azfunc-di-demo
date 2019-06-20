using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(DependencyInjection.Scopes.FunctionAppStartup))]

namespace DependencyInjection.Scopes
{
    public class FunctionAppStartup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            // Register MyServiceA as transient.
            // A new instance will be returned every
            // time a service request is made
            builder.Services.AddTransient<MyServiceA>();

            // Register MyServiceB as scoped.
            // The same instance will be returned
            // within the scope of a function invocation
            builder.Services.AddScoped<MyServiceB>();

            // Register ICommonIdProvider as scoped.
            // The same instance will be returned
            // within the scope of a function invocation
            builder.Services.AddScoped<ICommonIdProvider, CommonIdProvider>();


            // Register IGlobalIdProvider as singleton.
            // A single instance will be created and reused
            // with every service request
            builder.Services.AddSingleton<IGlobalIdProvider, CommonIdProvider>();
        }
    }
}
