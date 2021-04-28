namespace LegacyGT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VolunteerModNotRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Volunteer", "Modified", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Volunteer", "Modified", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
