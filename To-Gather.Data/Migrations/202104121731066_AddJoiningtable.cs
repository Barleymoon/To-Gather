namespace To_Gather.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJoiningtable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activity", "UserActivity_UserActivityId", "dbo.UserActivity");
            DropIndex("dbo.Activity", new[] { "UserActivity_UserActivityId" });
            AddColumn("dbo.UserActivity", "ActivityId", c => c.Int(nullable: false));
            AlterColumn("dbo.Event", "EventTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Activity", "UserActivity_UserActivityId");
            DropColumn("dbo.UserActivity", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserActivity", "Title", c => c.String());
            AddColumn("dbo.Activity", "UserActivity_UserActivityId", c => c.Int());
            AlterColumn("dbo.Event", "EventTime", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.UserActivity", "ActivityId");
            CreateIndex("dbo.Activity", "UserActivity_UserActivityId");
            AddForeignKey("dbo.Activity", "UserActivity_UserActivityId", "dbo.UserActivity", "UserActivityId");
        }
    }
}
