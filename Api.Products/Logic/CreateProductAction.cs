using Api.Products.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Utilities;

using Products;

using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Products.Logic
{
    public class CreateProductAction
    {
        private readonly IProductDB _database;

        public CreateProductAction(IProductDB database)
        {
            _database = database;
        }

        public IActionResult Do(Product product)
        {
            if (product.Id > 0)
                return new BadRequestObjectResult("Invalid Product Id.");

            _database.Create(product);

            return new OkResult();
        }
    }
}
