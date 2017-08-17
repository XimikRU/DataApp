using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using edX.DataApp.WebAPI.Models;

namespace edX.DataApp.WebAPI.Controllers
{
    public class ProductCategoriesController : ApiController
    {
        private ContosoContext _context;

        public ProductCategoriesController(ContosoContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductCategory> Get()
        {
            return _context.ProductCategories;
        }

        public ProductCategory Get(int id)
        {
            return _context.ProductCategories.Find(id);
        }

        // with json 
        public ProductCategory Post(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            _context.SaveChanges();
            return productCategory;
        }

        // api/ProductCategories/41 updating 41 category
        public ProductCategory Put(int id, ProductCategory productCategory)
        {
            productCategory.ProductCategoryId = id;
            _context.ProductCategories.Attach(productCategory);
            _context.Entry(productCategory).State = EntityState.Modified;
            _context.SaveChanges();
            return productCategory;
        }

        // 
        public void Delete(int id)
        {
            ProductCategory productCategory = _context.ProductCategories.Find(id);
            _context.ProductCategories.Remove(productCategory);
            _context.SaveChanges();
        }
    }
}
