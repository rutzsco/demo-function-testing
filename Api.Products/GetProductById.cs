using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Products
{
    public static class GetProductById
    {
        [FunctionName("GetProductById")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/products/{id}")] HttpRequest req, string id, ILogger log)
        {
            log.LogInformation("GetProductById HTTP trigger function invoked.");

            var products = Product.GetAllProducts();
            var p = products.Where(x => x.Id == id).FirstOrDefault();
            if (p == null)
                return new NotFoundResult();

            return new OkObjectResult(p);
        }
    }
}
