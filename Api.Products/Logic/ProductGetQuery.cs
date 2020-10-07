using Api.Products.Data;

using CSharpFunctionalExtensions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Utilities;

using Products;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Products.Logic
{
    public class ProductGetQuery
    {
        private readonly IProductDB _database;

        public ProductGetQuery(IProductDB database)
        {
            _database = database;
        }

        public async Task<Result<IEnumerable<Product>>> Execute()
        {
            var list = await _database.Get();
            return Result.Success(list);
        }
    }
}
