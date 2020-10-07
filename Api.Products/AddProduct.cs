using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Documents;
using Api.Products;
using Api.Products.Logic;
using Api.Products.Data;

namespace Products
{
    public static class AddProduct
    {
        [FunctionName("AddProduct")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "products")] HttpRequest req,
            [CosmosDB(databaseName: "ProductDatabase", collectionName: "Products", ConnectionStringSetting = "CosmosDBConnection")] IDocumentClient client, ILogger log)
        {
            log.LogInformation("AddProduct HTTP trigger function invoked.");

            var mappingResult = req.ToObject<Product>();
            if(!mappingResult.IsSuccess)
                return new BadRequestObjectResult(mappingResult.Error);

            var logic = new ProductCreateCommand(new ProductCosmosDB(client));
            logic.Execute(mappingResult.Value);

            return new OkResult();
        }
    }
}
