using ProductGrpc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductGrpc.Data
{
    public class ProductsContextSeed
    {
        public static async Task SeedAsync(ProductsContext productsContext)
        {
            if (!productsContext.Product.Any())
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        ProductId = 1,
                        Name = "Flutter",
                        Description = "Flutter Framework with Dart language",
                        Price = 0,
                        Status = ProductStatus.INSTOCK,
                        CreatedTime = DateTime.UtcNow
                    },
                    new Product
                    {
                        ProductId = 2,
                        Name = "MAUI",
                        Description = "MAUI Framework with C#",
                        Price = 0,
                        Status = ProductStatus.INSTOCK,
                        CreatedTime = DateTime.UtcNow
                    },
                    new Product
                    {
                        ProductId = 3,
                        Name = "React Native",
                        Description = "React",
                        Price = 0,
                        Status = ProductStatus.INSTOCK,
                        CreatedTime = DateTime.UtcNow
                    },
                    new Product
                    {
                        ProductId = 4,
                        Name = "IONIC",
                        Description = "Web based mobile framework",
                        Price = 0,
                        Status = ProductStatus.INSTOCK,
                        CreatedTime = DateTime.UtcNow
                    }
                };

                await productsContext.Product.AddRangeAsync(products);
                await productsContext.SaveChangesAsync();
            }
        }
    }
}
