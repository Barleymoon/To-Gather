namespace To_Gather.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Category", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Category", "Title");
        }
    }
}
