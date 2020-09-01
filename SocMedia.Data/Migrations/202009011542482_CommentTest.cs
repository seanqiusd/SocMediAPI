namespace SocMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "CommentPost_Id", "dbo.Post");
            DropForeignKey("dbo.Comment", "Author_Id", "dbo.SocMediaUser");
            DropIndex("dbo.Comment", new[] { "Author_Id" });
            DropIndex("dbo.Comment", new[] { "CommentPost_Id" });
            AddColumn("dbo.Comment", "SocMediaId", c => c.Guid(nullable: false));
            AddColumn("dbo.Comment", "PostId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comment", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Comment", "Author_Id", c => c.Guid(nullable: false));
            CreateIndex("dbo.Comment", "Author_Id");
            AddForeignKey("dbo.Comment", "Author_Id", "dbo.SocMediaUser", "Id", cascadeDelete: true);
            DropColumn("dbo.Comment", "Discriminator");
            DropColumn("dbo.Comment", "CommentPost_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "CommentPost_Id", c => c.Int());
            AddColumn("dbo.Comment", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.Comment", "Author_Id", "dbo.SocMediaUser");
            DropIndex("dbo.Comment", new[] { "Author_Id" });
            AlterColumn("dbo.Comment", "Author_Id", c => c.Guid());
            AlterColumn("dbo.Comment", "Text", c => c.String());
            DropColumn("dbo.Comment", "PostId");
            DropColumn("dbo.Comment", "SocMediaId");
            CreateIndex("dbo.Comment", "CommentPost_Id");
            CreateIndex("dbo.Comment", "Author_Id");
            AddForeignKey("dbo.Comment", "Author_Id", "dbo.SocMediaUser", "Id");
            AddForeignKey("dbo.Comment", "CommentPost_Id", "dbo.Post", "Id");
        }
    }
}
