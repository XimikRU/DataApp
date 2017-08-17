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
    builder.EntitySet<ProductCategories>("ProductCategories");
    builder.EntitySet<Products>("Products"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ProductCategoriesController : ODataController
    {
        private ContosoContext db = new ContosoContext();

        // GET: odata/ProductCategories
        [EnableQuery]
        public IQueryable<ProductCategories> GetProductCategories()
        {
            return db.ProductCategories;
        }

        // GET: odata/ProductCategories(5)
        [EnableQuery]
        public SingleResult<ProductCategories> GetProductCategories([FromODataUri] int key)
        {
            return SingleResult.Create(db.ProductCategories.Where(productCategories => productCategories.ProductCategoryId == key));
        }

        // PUT: odata/ProductCategories(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<ProductCategories> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductCategories productCategories = await db.ProductCategories.FindAsync(key);
            if (productCategories == null)
            {
                return NotFound();
            }

            patch.Put(productCategories);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoriesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(productCategories);
        }

        // POST: odata/ProductCategories
        public async Task<IHttpActionResult> Post(ProductCategories productCategories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductCategories.Add(productCategories);
            await db.SaveChangesAsync();

            return Created(productCategories);
        }

        // PATCH: odata/ProductCategories(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ProductCategories> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductCategories productCategories = await db.ProductCategories.FindAsync(key);
            if (productCategories == null)
            {
                return NotFound();
            }

            patch.Patch(productCategories);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoriesExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(productCategories);
        }

        // DELETE: odata/ProductCategories(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            ProductCategories productCategories = await db.ProductCategories.FindAsync(key);
            if (productCategories == null)
            {
                return NotFound();
            }

            db.ProductCategories.Remove(productCategories);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ProductCategories(5)/Products
        [EnableQuery]
        public IQueryable<Products> GetProducts([FromODataUri] int key)
        {
            return db.ProductCategories.Where(m => m.ProductCategoryId == key).SelectMany(m => m.Products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductCategoriesExists(int key)
        {
            return db.ProductCategories.Count(e => e.ProductCategoryId == key) > 0;
        }
    }
}
