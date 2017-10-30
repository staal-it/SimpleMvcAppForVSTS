namespace SimpleMVCApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStockProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fruit", "Stock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Fruit", "Stock");
        }
    }
}
