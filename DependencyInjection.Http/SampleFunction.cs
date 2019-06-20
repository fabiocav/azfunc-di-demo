using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace DependencyInjection.Http
{
    public class SampleFunction
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SampleFunction(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        [FunctionName("SimpleHttpClient")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await client.GetAsync("http://www.github.com/azure/azure-functions");

            return new StatusCodeResult((int)response.StatusCode);
        }
    }
}
