﻿using Api.Products.Data;

using CSharpFunctionalExtensions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Utilities;

using Products;

using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Products.Logic
{
    public class ProductCreateCommand
    {
        private readonly IProductDB _database;

        public ProductCreateCommand(IProductDB database)
        {
            _database = database;
        }

        public Result Execute(Product product)
        {
            if (product.Id > 0)
                return Result.Failure("Invalid Product Id.");

            _database.Create(product);

            return Result.Success();
        }
    }
}