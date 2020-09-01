namespace SocMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "SocMediaUser", c => c.Guid(nullable: false));
            CreateIndex("dbo.Post", "SocMediaUser");
            AddForeignKey("dbo.Post", "SocMediaUser", "dbo.SocMediaUser", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "SocMediaUser", "dbo.SocMediaUser");
            DropIndex("dbo.Post", new[] { "SocMediaUser" });
            DropColumn("dbo.Post", "SocMediaUser");
        }
    }
}
