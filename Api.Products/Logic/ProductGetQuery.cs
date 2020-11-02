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
    public class ProductQueries
    {
        private readonly IProductDB _database;

        public ProductQueries(IProductDB database)
        {
            _database = database;
        }

        public async Task<Result<IEnumerable<Product>>> GetAll()
        {
            var list = await _database.Get();
            return Result.Success(list);
        }

        public async Task<Result<Product>> GetById(string id)
        {
            var list = await _database.GetById(id);
            return Result.Success(list);
        }
    }
}
