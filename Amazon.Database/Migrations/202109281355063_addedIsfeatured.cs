namespace Amazon.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedIsfeatured : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "isfeatured", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "isfeatured");
        }
    }
}
