using Newtonsoft.Json;

using NUnit.Framework;

using System.Dynamic;
using System.Net.Http;
using System.Text;

namespace Api.Products.FunctionalTest
{
    [TestFixture]
    public class EndpointTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateProduct()
        {
            var product = new
            {
                id = "2",
                description = "description2",
                name = "name2"
            };


            var json = JsonConvert.SerializeObject(product);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://demo-function-testing-api.azurewebsites.net/api/products?code=25iGinHYa6u9B1kobnrgsupy45sYQMtype3vS55OoaZHcvuOV3nJLQ==";
            using (var client = new HttpClient())
            {
                var response =  client.PostAsync(url, data).Result;
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    Assert.Fail();
            }

            Assert.Pass();
        }

        [Test]
        public void GetProduct()
        {

            var url = "https://demo-function-testing-api.azurewebsites.net/api/products/2?code=IaD3PtdJ0HKymCQDVl9sISanDpe0P4653EsYrYc9JRCeSBFuDfQ4sw==";
            using (var client = new HttpClient())
            {
                var response = client.GetStringAsync(url).Result;
                dynamic product = Newtonsoft.Json.JsonConvert.DeserializeObject<ExpandoObject>(response);
                Assert.AreEqual(2, product.id);
                Assert.AreEqual("description2", product.description);
                Assert.AreEqual("name2", product.name);
            }
        }
    }
}