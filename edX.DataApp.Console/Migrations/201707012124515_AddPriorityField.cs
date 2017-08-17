namespace edX.DataApp.Console.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriorityField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Partners", "Priority", c => c.Int(nullable: false));
        }                                                                                            
        
        public override void Down()
        {
            DropColumn("dbo.Partners", "Priority");
        }
    }
}
