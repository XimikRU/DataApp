using System;
using System.Collections.Generic;
using System.Text;

namespace edX.DataApp.Lab.CoreConsole
{
    public class ModifyingDatabaseData
    {
        public void RunChangeLogic(ContosoContext context)
        {
            Product hlRoadFrame = context.Products.Find(680);
            hlRoadFrame.Color = "Pink";
            context.SaveChanges();
        }

        public void RunAddLogic(ContosoContext context)
        {
            Product bestBikeEver = new Product
            {
                Name = "Best Accessory Ever",
                ProductNumber = "BAE-123",
                ListPrice = 1000,
                StandardCost = 500,
                Color = "Gold",
                ProductCategoryId = 1
            };
            Console.WriteLine("Old Id:\t" + bestBikeEver.ProductId);
            context.Products.Add(bestBikeEver);
            context.SaveChanges();
            Console.WriteLine("New Id:\t" + bestBikeEver.ProductId);
        }
    }
}
