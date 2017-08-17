using System;
using System.Collections.Generic;
using System.Text;

namespace edX.DataApp.Lab.CoreConsole
{
    public class DatabaseTransactions
    {
        public void RunLogic(ContosoContext context)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                ProductCategory newCategory = new ProductCategory
                {
                    Name = "Internet Connected"
                    //ProductCategoryId = 20
                };
                context.ProductCategories.Add(newCategory);
                context.SaveChanges();

                var newProduct = new Product
                {
                    Name = "Smart Cycling Computer",
                    ProductCategoryId = newCategory.ProductCategoryId,
                    ProductNumber = "SCC-123",
                    ListPrice = 1200,
                    StandardCost = 500,
                    Color = "White",
                };
                context.Products.Add(newProduct);
                context.SaveChanges();
                
                transaction.Commit();
                Console.WriteLine(newProduct.ProductCategoryId);
            }
        }
    }
}
