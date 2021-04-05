namespace To_Gather.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserActivity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserActivity",
                c => new
                    {
                        UserActivityId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        OwnerId = c.Guid(nullable: false),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserActivityId)
                .ForeignKey("dbo.UserProfile", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.ProfileId);
            
            AddColumn("dbo.Activity", "UserActivity_UserActivityId", c => c.Int());
            CreateIndex("dbo.Activity", "UserActivity_UserActivityId");
            AddForeignKey("dbo.Activity", "UserActivity_UserActivityId", "dbo.UserActivity", "UserActivityId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activity", "UserActivity_UserActivityId", "dbo.UserActivity");
            DropForeignKey("dbo.UserActivity", "ProfileId", "dbo.UserProfile");
            DropIndex("dbo.UserActivity", new[] { "ProfileId" });
            DropIndex("dbo.Activity", new[] { "UserActivity_UserActivityId" });
            DropColumn("dbo.Activity", "UserActivity_UserActivityId");
            DropTable("dbo.UserActivity");
        }
    }
}
