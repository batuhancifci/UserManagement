namespace UserManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Role", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Role", c => c.String(maxLength: 20));
        }
    }
}
