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
        public void DataSeed()
        {
            try
            {
                if (_dbContext.Database.GetPendingMigrations().Any())
                {
                    _dbContext.Database.Migrate();
                }
                if (!_dbContext.productBrands.Any())
                {
                    var ProductBrandData = File.ReadAllText("..\\Infrastructure\\Presistence\\Data\\DataSead\\brands.json");

                    var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(ProductBrandData);
                    if (productBrands is not null && productBrands.Any())
                        _dbContext.AddRange(productBrands);
                }
                if (!_dbContext.productTypes.Any())
                {
                    var ProductTypeData = File.ReadAllText("..\\Infrastructure\\Presistence\\Data\\DataSead\\types.json");

                    var productTypes = JsonSerializer.Deserialize<List<ProductBrand>>(ProductTypeData);
                    if (productTypes is not null && productTypes.Any())
                        _dbContext.AddRange(productTypes);
                }
                if (!_dbContext.products.Any())
                {
                    var ProductData = File.ReadAllText("..\\Infrastructure\\Presistence\\Data\\DataSead\\products.json");

                    var products = JsonSerializer.Deserialize<List<ProductBrand>>(ProductData);
                    if (products is not null && products.Any())
                        _dbContext.AddRange(products);
                }
            }
            catch (Exception ex)
            {
                //hh
            }
        }
    }
}
