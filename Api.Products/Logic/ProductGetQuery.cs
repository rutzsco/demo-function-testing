using Api.Products.Data;

using CSharpFunctionalExtensions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Utilities;

using Products;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Products.Logic
{
    public class ProductGetQuery
    {
        private readonly IProductDB _database;

        public ProductGetQuery(IProductDB database)
        {
            _database = database;
        }

        public Result<IEnumerable<Product>> Execute()
        {
            return Result.Success(Enumerable.Empty<Product>());
        }
    }
}
