namespace To_Gather.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activity",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false, maxLength: 150),
                        Equipment = c.String(nullable: false),
                        CatgoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityId)
                .ForeignKey("dbo.Category", t => t.CatgoryId, cascadeDelete: true)
                .Index(t => t.CatgoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activity", "CatgoryId", "dbo.Category");
            DropIndex("dbo.Activity", new[] { "CatgoryId" });
            DropTable("dbo.Activity");
        }
    }
}
