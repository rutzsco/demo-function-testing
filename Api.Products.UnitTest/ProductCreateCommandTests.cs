using Api.Products.Data;
using Api.Products.Logic;

using Moq;

using NUnit.Framework;

using Products;

using System.Threading.Tasks;

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
            var p1 = new Product() { Id = "1", Description = "Description", Name = "Product 1" };

            var mock = new Mock<IProductDB>(MockBehavior.Strict);
            mock.Setup(db => db.Create(p1)).Returns(Task.CompletedTask);

            var command = new ProductCreateCommand(mock.Object);
            var result = command.Execute(p1);
            Assert.AreEqual(true, result.IsSuccess);
        }

        [Test]
        public void Execute_ValidationError_Invalid_Id()
        {
            var command = new ProductCreateCommand(null);
            var result = command.Execute(new Product() { Id = "0", Description = "Description", Name = "Product 1" });
            Assert.AreEqual(false, result.IsSuccess);
            Assert.AreEqual(true, result.Error.Length > 0);
        }
    }
}