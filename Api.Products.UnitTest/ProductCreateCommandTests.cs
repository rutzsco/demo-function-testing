using Api.Products.Logic;

using NUnit.Framework;

using Products;

namespace Api.Products.UnitTest
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Execute_Success()
        {
            var command = new ProductCreateCommand(null);
            var result = command.Execute(new Product() { Id = 2, Description = "Description", Name = "Product 1"});
            Assert.AreEqual(true, result.IsSuccess);
        }

        [Test]
        public void Execute_ValidationError_Invalid_Id()
        {
            var command = new ProductCreateCommand(null);
            var result = command.Execute(new Product() { Id = 0, Description = "Description", Name = "Product 1" });
            Assert.AreEqual(false, result.IsSuccess);
            Assert.AreEqual(true, result.Error.Length > 0);
        }
    }
}