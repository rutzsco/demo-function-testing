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
    public static class Verify2Endpoint
    {
        [FunctionName("Verify2Endpoint")]
        public static IActionResult Run2([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "loaderio-34491d16cf055637d8fa54209d63c993")] HttpRequest req)
        {
            return new OkObjectResult("loaderio-34491d16cf055637d8fa54209d63c993");
        }

        [FunctionName("Verify3Endpoint")]
        public static IActionResult Run3([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "loaderio-34491d16cf055637d8fa54209d63c993")] HttpRequest req)
        {
            return new OkObjectResult("loaderio-34491d16cf055637d8fa54209d63c993");
        }
    }
}
