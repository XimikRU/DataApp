namespace edX.DataApp.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInternalId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Partners", "InternalId", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Partners", "InternalId");
        }

        
    }
}
