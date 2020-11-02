using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Products
{
    public static class DeleteProducts
    {
        [FunctionName("DeleteProducts")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "api/products")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("DeleteProducts HTTP trigger function invoked.");
            return new NoContentResult();
        }
    }
}
