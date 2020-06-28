using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context,ILoggerFactory loggerfactory)
        {
            try
            {
                if(!context.ProductBrands.Any())
                {
                    var brandData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    var brand = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

                    foreach(var item in brand)
                    {
                        context.ProductBrands.Add(item);
                    }

                    await context.SaveChangesAsync();
                }                

                if (!context.ProductTypes.Any())
                {
                    var productTypeData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    var productType = JsonSerializer.Deserialize<List<ProductType>>(productTypeData);

                    foreach (var item in productType)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    var product = JsonSerializer.Deserialize<List<Product>>(productData);

                    foreach (var item in product)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                var logger = loggerfactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
