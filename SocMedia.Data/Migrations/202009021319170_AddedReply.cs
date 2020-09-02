namespace SocMedia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReply : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "CommentId", c => c.Int());
            AddColumn("dbo.Comment", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Comment", "CommentId");
            AddForeignKey("dbo.Comment", "CommentId", "dbo.Comment", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "CommentId", "dbo.Comment");
            DropIndex("dbo.Comment", new[] { "CommentId" });
            DropColumn("dbo.Comment", "Discriminator");
            DropColumn("dbo.Comment", "CommentId");
        }
    }
}
