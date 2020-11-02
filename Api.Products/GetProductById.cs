using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using Api.Products.Logic;
using Api.Products.Data;
using Microsoft.Azure.Documents;
using System.Threading.Tasks;

namespace Products
{
    public static class GetProductById
    {
        [FunctionName("GetProductById")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "api/products/{id}")] HttpRequest req, string id, [CosmosDB(ConnectionStringSetting = "CosmosDBConnection")] IDocumentClient client, ILogger log)
        {
            log.LogInformation("GetProductById HTTP trigger function invoked.");

            var logic = new ProductQueries(new ProductCosmosDB(client));
            var result = await logic.GetById(id);
            return new OkObjectResult(result.Value);
        }
    }
}
