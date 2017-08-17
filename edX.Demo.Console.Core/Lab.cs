using System;
using System.Collections.Generic;
using System.Text;

namespace edX.DataApp.Lab.CoreConsole
{
    public class Lab
    {
        public void RunLogic(ContosoContext context)
        {
            Console.WriteLine($"{"Product",10}\t{"Price",10}\t{"Cost",10}\t{"Profit",10}");
            Console.WriteLine("------------------------------------------------------------");
            foreach (var product in context.Products)
            {
                Console.WriteLine($"{product.ProductNumber,10}\t{product.ListPrice,10:C}\t" +
                    $"{product.StandardCost,10:C}\t{(product.ListPrice - product.StandardCost),10:C}");
                Console.WriteLine("------------------------------------------------------------");
            }
        }
    }
}
