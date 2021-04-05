namespace To_Gather.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        UserName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ProfileId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfile");
        }
    }
}
