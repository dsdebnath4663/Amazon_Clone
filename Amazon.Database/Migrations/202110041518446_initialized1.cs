namespace Amazon.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialized1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "usersImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "usersImageUrl");
        }
    }
}
