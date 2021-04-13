namespace To_Gather.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventUserAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserEvent",
                c => new
                    {
                        UserEventId = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        ProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserEventId)
                .ForeignKey("dbo.Event", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfile", t => t.ProfileId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.ProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserEvent", "ProfileId", "dbo.UserProfile");
            DropForeignKey("dbo.UserEvent", "EventId", "dbo.Event");
            DropIndex("dbo.UserEvent", new[] { "ProfileId" });
            DropIndex("dbo.UserEvent", new[] { "EventId" });
            DropTable("dbo.UserEvent");
        }
    }
}
