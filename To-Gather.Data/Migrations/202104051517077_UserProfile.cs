namespace To_Gather.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "CreatedUser", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfile", "CreatedUser");
        }
    }
}
