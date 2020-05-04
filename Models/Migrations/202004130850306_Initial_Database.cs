namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PageComments",
                c => new
                    {
                        PageCommentId = c.Int(nullable: false, identity: true),
                        Pageid = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                        Email = c.String(maxLength: 150),
                        WebSite = c.String(maxLength: 150),
                        Commment = c.String(nullable: false, maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PageCommentId)
                .ForeignKey("dbo.Pages", t => t.Pageid, cascadeDelete: true)
                .Index(t => t.Pageid);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        PageDescription = c.String(nullable: false, maxLength: 150),
                        Text = c.String(nullable: false, maxLength: 150),
                        Visit = c.Int(nullable: false),
                        ImageName = c.String(),
                        ShowInSlider = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PageId)
                .ForeignKey("dbo.PageGroups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.PageGroups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupTitle = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "GroupId", "dbo.PageGroups");
            DropForeignKey("dbo.PageComments", "Pageid", "dbo.Pages");
            DropIndex("dbo.Pages", new[] { "GroupId" });
            DropIndex("dbo.PageComments", new[] { "Pageid" });
            DropTable("dbo.PageGroups");
            DropTable("dbo.Pages");
            DropTable("dbo.PageComments");
        }
    }
}
