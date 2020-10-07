using Api.Products;
using Api.Products.Data;
using Api.Products.Logic;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

using System.Threading.Tasks;

namespace Products
{
    public static class AddProduct
    {
        [FunctionName("AddProduct")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "products")] HttpRequest req,
                                                    [CosmosDB(ConnectionStringSetting = "CosmosDBConnection")] IDocumentClient client, ILogger log)
        {
            log.LogInformation("AddProduct HTTP trigger function invoked.");
            
            // Initialize
            var logic = new ProductCreateCommand(new ProductCosmosDB(client));
           
            // Execute
            return await WorkflowRunner.Execute(() => { return req.Body.ToObject<Product>(); }, (request) => { return logic.Execute(request); });
        }
    }
}
