using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

using Products;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Products.Data
{
    public interface IProductDB
    {
        Task Create(Product product);
    }

    public class ProductCosmosDB : IProductDB
    {
        private readonly IDocumentClient _client;

        public ProductCosmosDB(IDocumentClient client)
        {
            _client = client;
        }

        public async Task Create(Product product)
        {
            var uri = UriFactory.CreateDocumentCollectionUri("ProductDatabase", "Products");
            await _client.CreateDocumentAsync(uri, product);
        }
    }
}
