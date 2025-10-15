﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presistence.Data
{
    public class DataSeeding(StoreDbContext _dbContext) : IDataSeeding

    {


       
        public async Task SeedDataAsync()
        {

            try
            {
                var pendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();  
                if (pendingMigrations.Any())
                {
                   await _dbContext.Database.MigrateAsync();
                }
                if (!_dbContext.ProductBrands.Any())
                {
                    var ProductBrandData = File.OpenRead("..//Infrastructure//Presistence//Data//DataSeed//brands.json");
                    //Json ==>C# object [list<ProductBrand>]
                    var productBrands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProductBrandData);
                    if (productBrands != null && productBrands.Any())
                    {
                       await _dbContext.ProductBrands.AddRangeAsync(productBrands);
                    }
                }

                if (!_dbContext.ProductTypes.Any())
                {
                    var ProductTypesData = File.OpenRead("..//Infrastructure//Presistence//Data//DataSeed//types.json");
                    var productTypes = await JsonSerializer.DeserializeAsync<List<ProductType>>(ProductTypesData);
                    if (productTypes is not null && productTypes.Any())
                    await    _dbContext.ProductTypes.AddRangeAsync(productTypes);

                }

                if (!_dbContext.Products.Any())
                {
                    var ProductsData = File.OpenRead("..//Infrastructure//Presistence//Data//DataSeed//products.json");
                    var products = await JsonSerializer.DeserializeAsync<List<Product>>(ProductsData);
                    if (products is not null && products.Any())
                       await _dbContext.Products.AddRangeAsync(products);
                }

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw; 
            }

        }
    }
}
