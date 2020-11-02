using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Documents;
using Api.Products.Data;
using Api.Products.Logic;
using System.Threading.Tasks;

namespace Products
{
    public static class GetProducts
    {
        [FunctionName("GetProducts")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "products")] HttpRequest req, 
            [CosmosDB(ConnectionStringSetting = "CosmosDBConnection")] IDocumentClient client, ILogger log)
        {
            log.LogInformation("GetProducts trigger function invoked.");

            var logic = new ProductGetQuery(new ProductCosmosDB(client));
            var result = await logic.Execute();

            return new OkObjectResult(result.Value);
        }
    }
}
