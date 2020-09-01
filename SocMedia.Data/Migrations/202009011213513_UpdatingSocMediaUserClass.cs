namespace SocMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingSocMediaUserClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Author_Id = c.Guid(),
                        CommentPost_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SocMediaUser", t => t.Author_Id)
                .ForeignKey("dbo.Post", t => t.CommentPost_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.CommentPost_Id);
            
            AlterColumn("dbo.SocMediaUser", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.SocMediaUser", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.SocMediaUser", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "CommentPost_Id", "dbo.Post");
            DropForeignKey("dbo.Comment", "Author_Id", "dbo.SocMediaUser");
            DropIndex("dbo.Comment", new[] { "CommentPost_Id" });
            DropIndex("dbo.Comment", new[] { "Author_Id" });
            AlterColumn("dbo.SocMediaUser", "Email", c => c.String());
            AlterColumn("dbo.SocMediaUser", "LastName", c => c.String());
            AlterColumn("dbo.SocMediaUser", "FirstName", c => c.String());
            DropTable("dbo.Comment");
        }
    }
}