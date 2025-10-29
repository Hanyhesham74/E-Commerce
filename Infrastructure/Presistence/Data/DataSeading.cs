using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presistence.Data
{
    public class DataSeading (StoreDbContext _dbContext): IDataSeading
    {
        public async Task DataSeedAsync()
        { 
            try
            {
                if ((await _dbContext.Database.GetAppliedMigrationsAsync()).Any())
                {
                   await _dbContext.Database.MigrateAsync();
                }
                if (!_dbContext.productBrands.Any())
                {
                    var ProductBrandData = File.OpenRead("..\\Infrastructure\\Presistence\\Data\\DataSead\\brands.json");

                    var productBrands =await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProductBrandData);
                    if (productBrands is not null && productBrands.Any())
                      await  _dbContext.AddRangeAsync(productBrands);
                }
                if (!_dbContext.productTypes.Any())
                {
                    var ProductTypeData = File.OpenRead("..\\Infrastructure\\Presistence\\Data\\DataSead\\types.json");

                    var productTypes =await JsonSerializer.DeserializeAsync<List<ProductType>>(ProductTypeData);
                    if (productTypes is not null && productTypes.Any())
                      await  _dbContext.AddRangeAsync(productTypes);
                }
                if (!_dbContext.products.Any())
                {
                    var ProductData = File.OpenRead("..\\Infrastructure\\Presistence\\Data\\DataSead\\products.json");

                    var products =await JsonSerializer.DeserializeAsync<List<Product>>(ProductData);
                    if (products is not null && products.Any())
                       await _dbContext.AddRangeAsync(products);
                }
               await _dbContext.SaveChangesAsync(); 
            }
            catch (Exception ex)
            {
                //hh
            }
        }
    }
}
