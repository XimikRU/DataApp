using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace edX.DataApp.Lab.CoreConsole
{
    public class ProductQuery
    {
        public void RunLogic(ContosoContext context)
        {
            // Add a new line of code to expand the LINQ query by filtering the results to records that have a value 
            // of true for the SafetyReviewResult property. To accomplish this, reference the SafetyReviewResult 
            // nullable property and use the null coalescing operator to return false if the property is null:
            IEnumerable<Product> products = 
                from product in context.Products
                where product.SafetyReviewResult ?? false
                select product;

            foreach (Product product in products)
            {
                Console.WriteLine($"[{product.ProductNumber}]\t{product.Name,35}\tPassed Review: {product.SafetyReviewResult}");
            }
        }
    }
}
