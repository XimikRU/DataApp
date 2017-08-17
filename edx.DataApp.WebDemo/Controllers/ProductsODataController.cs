using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using edx.DataApp.WebDemo.Models;

namespace edx.DataApp.WebDemo.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using edx.DataApp.WebDemo.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Products>("ProductsOData");
    builder.EntitySet<ProductCategories>("ProductCategories"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ProductsODataController : ODataController
    {
        private ContosoContext db = new ContosoContext();

        // GET: odata/ProductsOData
        [EnableQuery]
        public IQueryable<Products> GetProductsOData()
        {
            return db.Products;
        }

        // GET: odata/ProductsOData(5)
        [EnableQuery]
        public SingleResult<Products> GetProducts([FromODataUri] int key)
        {
            return SingleResult.Create(db.Products.Where(products => products.ProductID == key));
        }

        // PUT: odata/ProductsOData(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Products> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Products products = await db.Products.FindAsync(key);
            if (products == null)
            {
                return NotFound();
            }

            patch.Put(products);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(products);
        }

        // POST: odata/ProductsOData
        public async Task<IHttpActionResult> Post(Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(products);
            await db.SaveChangesAsync();

            return Created(products);
        }

        // PATCH: odata/ProductsOData(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Products> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Products products = await db.Products.FindAsync(key);
            if (products == null)
            {
                return NotFound();
            }

            patch.Patch(products);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(products);
        }

        // DELETE: odata/ProductsOData(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Products products = await db.Products.FindAsync(key);
            if (products == null)
            {
                return NotFound();
            }

            db.Products.Remove(products);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ProductsOData(5)/ProductCategories
        [EnableQuery]
        public SingleResult<ProductCategories> GetProductCategories([FromODataUri] int key)
        {
            return SingleResult.Create(db.Products.Where(m => m.ProductID == key).Select(m => m.ProductCategories));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductsExists(int key)
        {
            return db.Products.Count(e => e.ProductID == key) > 0;
        }
    }
}
