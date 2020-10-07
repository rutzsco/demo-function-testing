using Api.Products.Data;
using Api.Products.Logic;

using Moq;

using NUnit.Framework;

using Products;
using Api.Products;

using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Api.Products.UnitTest
{
    [TestFixture]
    public class ExtensionsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Execute_ToObject_Success()
        {
            var request = GenerateEmbededFileAsStream("Api.Products.UnitTest.SampleReqest.json");
            var mappingResult = request.ToObject<Product>();

            Assert.AreEqual(true, mappingResult.IsSuccess);
        }

        [Test]
        public void Execute_ToObject_NoContent()
        {
            var emptyStream = new MemoryStream();
            var mappingResult = emptyStream.ToObject<Product>();

            Assert.AreEqual(false, mappingResult.IsSuccess);
            Assert.AreEqual("Invalid request - No request body.", mappingResult.Error);
        }

        public static Stream GenerateEmbededFileAsStream(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream(resourceName);
        }
    }
}