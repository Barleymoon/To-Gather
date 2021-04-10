namespace To_Gather.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Title = c.String(nullable: false, maxLength: 15),
                        Description = c.String(nullable: false, maxLength: 200),
                        EventTime = c.DateTimeOffset(nullable: false, precision: 7),
                        IsOfAge = c.Boolean(nullable: false),
                        LocationId = c.Int(nullable: false),
                        ActivityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Activity", t => t.ActivityId, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.ActivityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Event", "ActivityId", "dbo.Activity");
            DropIndex("dbo.Event", new[] { "ActivityId" });
            DropIndex("dbo.Event", new[] { "LocationId" });
            DropTable("dbo.Event");
        }
    }
}
