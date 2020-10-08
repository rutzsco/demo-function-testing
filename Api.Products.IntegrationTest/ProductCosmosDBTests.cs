using Api.Products.Data;

using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;

using NUnit.Framework;

using Products;

using System;
using System.Data.Common;
using System.Linq;

namespace Api.Products.IntegrationTest
{
    [TestFixture]
    public class ProductCosmosDBTests
    {
        private DocumentClient _Client;

        [SetUp]
        public void Setup()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("local.settings.json", true)
                .AddEnvironmentVariables()
                .Build();

            var dbConnectionStringBuilder = new DbConnectionStringBuilder() { ConnectionString = config["CosmosDBConnection"] };
            var accountEndpoint = (string)dbConnectionStringBuilder["AccountEndpoint"];
            var accountKey = (string)dbConnectionStringBuilder["AccountKey"];

            _Client = new DocumentClient(new Uri(accountEndpoint), accountKey);
        }

        [Test]
        public void CreateGetTest()
        {
            var db = new ProductCosmosDB(_Client);
            try
            {
                db.Create(new Product() { Id = "3", Description = "description3", Name = "name3" }).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                return;
            }

            var products = db.Get().Result;
            Assert.AreEqual(true, products.Count() > 0);
        }
    }
}