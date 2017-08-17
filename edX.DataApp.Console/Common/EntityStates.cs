using edX.DataApp.Console.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edX.DataApp.Console
{
    class EntityStates
    {
        public void RunLogic(ContosoCodeModel context)
        {
            var partner = new Partner { Name = "DEMO" };
            var existingPartner = context.Partners.Where(p => p.Name == "Bob").Single();
            context.Entry(partner).State = EntityState.Added;
            //context.SaveChanges();

            existingPartner.IsOpen = false;
            context.Partners.Attach(existingPartner);
            //context.Entry(existingBlog).State = EntityState.Modified;
            //context.SaveChanges();


            // Disabling tracking
            var untrackedPartners = context.Partners.AsNoTracking();
            var trackedPartner = context.Partners.Single(p => p.PartnerId == 60);
            context.Entry(trackedPartner).State = EntityState.Detached;
        }
    }
}
