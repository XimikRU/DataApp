namespace edX.DataApp.Console.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<edX.DataApp.Console.ContosoCodeModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        // Seed overrirde to customize migration // HM
        protected override void Seed(edX.DataApp.Console.ContosoCodeModel context)
        {
            
            var partnersWithoutId = context.Partners.Where(p => !p.InternalId.HasValue);
            foreach (var partner in partnersWithoutId)
            {
                partner.InternalId = Guid.NewGuid();
            }
            context.SaveChanges();
            
        }
    }
}
