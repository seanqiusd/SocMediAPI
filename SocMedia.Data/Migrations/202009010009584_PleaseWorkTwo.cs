namespace SocMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PleaseWorkTwo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        Author_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SocMediaUser", t => t.Author_Id, cascadeDelete: true)
                .Index(t => t.Author_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "Author_Id", "dbo.SocMediaUser");
            DropIndex("dbo.Post", new[] { "Author_Id" });
            DropTable("dbo.Post");
        }
    }
}
