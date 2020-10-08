using Api.Products.Data;

using CSharpFunctionalExtensions;

using Products;

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
            if (string.IsNullOrEmpty(product.Id))
                return Result.Failure("Invalid Product Id.");

  
            _database.Create(product);

            return Result.Success();
        }
    }
}
