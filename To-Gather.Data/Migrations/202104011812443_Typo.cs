namespace To_Gather.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Typo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Activity", name: "CatgoryId", newName: "CategoryId");
            RenameIndex(table: "dbo.Activity", name: "IX_CatgoryId", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Activity", name: "IX_CategoryId", newName: "IX_CatgoryId");
            RenameColumn(table: "dbo.Activity", name: "CategoryId", newName: "CatgoryId");
        }
    }
}
