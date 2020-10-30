using CSharpFunctionalExtensions;

using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

using Newtonsoft.Json;

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

        Task<IEnumerable<Product>> Get();
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
            var response = await _client.CreateDocumentAsync(uri, product);
            if (response.StatusCode != System.Net.HttpStatusCode.Created)
                throw new Exception("DB Call Failed");
        }

        public async Task<IEnumerable<Product>> Get()
        {
            var list = new List<Product>(); 
            string continuationToken = null;
            var uri = UriFactory.CreateDocumentCollectionUri("ProductDatabase", "Products");
            do
            {
                var feed = await _client.ReadDocumentFeedAsync(uri, new FeedOptions { MaxItemCount = 10, RequestContinuation = continuationToken });
                continuationToken = feed.ResponseContinuation;
                foreach (Document document in feed)
                {
                    list.Add(JsonConvert.DeserializeObject<Product>(document.ToString()));
                }
            } while (continuationToken != null);

            return list;
        }
    }
}
