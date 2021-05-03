namespace LegacyGT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedVolunteer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Volunteer", "Positions", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Volunteer", "Positions");
        }
    }
}
