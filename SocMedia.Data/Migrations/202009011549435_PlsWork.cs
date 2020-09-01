namespace SocMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlsWork : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comment", "SocMediaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "SocMediaId", c => c.Guid(nullable: false));
        }
    }
}
