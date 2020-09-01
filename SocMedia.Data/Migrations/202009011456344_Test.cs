namespace SocMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        UserId = c.Guid(nullable: false),
                        SocMediaUser_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.SocMediaUser", t => t.SocMediaUser_Id)
                .Index(t => t.PostId)
                .Index(t => t.SocMediaUser_Id);
            
            AddColumn("dbo.Post", "Author_Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.SocMediaUser", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.SocMediaUser", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.SocMediaUser", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Post", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Post", "Text", c => c.String(nullable: false));
            CreateIndex("dbo.Post", "Author_Id");
            AddForeignKey("dbo.Post", "Author_Id", "dbo.SocMediaUser", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Like", "SocMediaUser_Id", "dbo.SocMediaUser");
            DropForeignKey("dbo.Like", "PostId", "dbo.Post");
            DropForeignKey("dbo.Post", "Author_Id", "dbo.SocMediaUser");
            DropIndex("dbo.Like", new[] { "SocMediaUser_Id" });
            DropIndex("dbo.Like", new[] { "PostId" });
            DropIndex("dbo.Post", new[] { "Author_Id" });
            AlterColumn("dbo.Post", "Text", c => c.String());
            AlterColumn("dbo.Post", "Title", c => c.String());
            AlterColumn("dbo.SocMediaUser", "Email", c => c.String());
            AlterColumn("dbo.SocMediaUser", "LastName", c => c.String());
            AlterColumn("dbo.SocMediaUser", "FirstName", c => c.String());
            DropColumn("dbo.Post", "Author_Id");
            DropTable("dbo.Like");
        }
    }
}
