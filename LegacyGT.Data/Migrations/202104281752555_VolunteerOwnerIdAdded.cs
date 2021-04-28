namespace LegacyGT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VolunteerOwnerIdAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Volunteer", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Volunteer", "OwnerId");
        }
    }
}
