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
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "loaderio-960b7d2843c53118d74da561507e6e31")] HttpRequest req)
        {
            return new OkObjectResult("loaderio-960b7d2843c53118d74da561507e6e31");
        }
    }
}
