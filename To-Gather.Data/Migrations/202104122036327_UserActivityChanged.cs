namespace To_Gather.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserActivityChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserActivity", "ProfileId", "dbo.UserProfile");
            DropIndex("dbo.UserActivity", new[] { "ProfileId" });
            CreateTable(
                "dbo.UsersActivity",
                c => new
                    {
                        UsersActivityId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        ActivityId = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsersActivityId)
                .ForeignKey("dbo.Activity", t => t.ActivityId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfile", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.ActivityId)
                .Index(t => t.ProfileId);
            
            DropTable("dbo.UserActivity");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserActivity",
                c => new
                    {
                        UserActivityId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        ActivityId = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserActivityId);
            
            DropForeignKey("dbo.UsersActivity", "ProfileId", "dbo.UserProfile");
            DropForeignKey("dbo.UsersActivity", "ActivityId", "dbo.Activity");
            DropIndex("dbo.UsersActivity", new[] { "ProfileId" });
            DropIndex("dbo.UsersActivity", new[] { "ActivityId" });
            DropTable("dbo.UsersActivity");
            CreateIndex("dbo.UserActivity", "ProfileId");
            AddForeignKey("dbo.UserActivity", "ProfileId", "dbo.UserProfile", "ProfileId", cascadeDelete: true);
        }
    }
}
