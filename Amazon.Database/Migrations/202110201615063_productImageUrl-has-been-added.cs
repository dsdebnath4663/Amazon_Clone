namespace Amazon.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productImageUrlhasbeenadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(nullable: false, maxLength: 500),
                        isfeatured = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 600),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        productImageUrl = c.String(),
                        Name = c.String(nullable: false, maxLength: 60),
                        Description = c.String(maxLength: 600),
                        Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.Configs",
                c => new
                    {
                        key = c.String(nullable: false, maxLength: 128),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.key);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        password = c.String(),
                        address = c.String(),
                        usersImageUrl = c.String(),
                        Name = c.String(nullable: false, maxLength: 60),
                        Description = c.String(maxLength: 600),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Category_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.Configs");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
