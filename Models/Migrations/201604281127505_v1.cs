namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Scans");
            AlterColumn("dbo.Scans", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Scans", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Scans");
            AlterColumn("dbo.Scans", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Scans", "Id");
        }
    }
}
