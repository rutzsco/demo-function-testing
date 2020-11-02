using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api.Products
{
    public static class VerifyEndpoint
    {
        [FunctionName("VerifyEndpoint")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "loaderio-f87f3bbfeae57b849bdda6ba5937d2e8")] HttpRequest req)
        {
            return new OkObjectResult("loaderio-f87f3bbfeae57b849bdda6ba5937d2e8");
        }
    }
}
