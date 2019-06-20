using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DependencyInjection.Scopes
{
    public static class Function1
    {
        public class SampleFunction
        {
            private readonly MyServiceA _serviceA;
            private readonly MyServiceB _serviceB;
            private readonly IGlobalIdProvider _globalIdProvider;

            public SampleFunction(MyServiceA serviceA, MyServiceB serviceB, IGlobalIdProvider globalIdProvider)
            {
                _serviceA = serviceA ?? throw new ArgumentNullException(nameof(serviceA));
                _serviceB = serviceB ?? throw new ArgumentNullException(nameof(serviceB));
                _globalIdProvider = globalIdProvider ?? throw new ArgumentNullException(nameof(globalIdProvider));
            }

            [FunctionName("SampleFunction")]
            public IActionResult Run(
                [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
                ILogger log)
            {
                log.LogInformation($"Service A ID: {_serviceA.IdProvider.Id}. Service B ID: {_serviceB.IdProvider.Id}");

                return new OkObjectResult(new
                {
                    ProvidersMatch = ReferenceEquals(_serviceA.IdProvider, _serviceB.IdProvider),
                    GlobalId = _globalIdProvider.Id,
                    ServiceAId = _serviceA.IdProvider.Id,
                    ServiceBId = _serviceB.IdProvider.Id
                });
            }
        }
    }
}
