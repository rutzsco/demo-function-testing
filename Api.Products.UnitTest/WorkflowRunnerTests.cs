using Api.Products.Data;
using Api.Products.Logic;

using Moq;

using NUnit.Framework;

using Products;
using Api.Products;

using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Products.UnitTest
{
    [TestFixture]
    public class WorkflowRunnerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Execute_Mapping_Failure()
        {
            var r =  WorkflowRunner.Execute(() => { return Result.Failure<Product>("Invalid Request"); }, (request) => { return Result.Success(); }).Result;
            Assert.AreEqual(true, r is BadRequestObjectResult);
            var br = r as BadRequestObjectResult;
            Assert.AreEqual("Invalid Request", br.Value);
        }

        [Test]
        public void Execute_Logic_Failure()
        {
            var r = WorkflowRunner.Execute(() => { return Result.Success(new Product()); }, (request) => { return Result.Failure("Logic Failure"); }).Result;
            Assert.AreEqual(true, r is BadRequestObjectResult);
            var br = r as BadRequestObjectResult;
            Assert.AreEqual("Logic Failure", br.Value);
        }

        [Test]
        public void Execute_Logic_Success()
        {
            var r = WorkflowRunner.Execute(() => { return Result.Success(new Product()); }, (request) => { return Result.Success(); }).Result;
            Assert.AreEqual(true, r is OkResult);
        }
    }
}