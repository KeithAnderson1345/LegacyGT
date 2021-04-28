namespace LegacyGT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sponsormodnotrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sponsor", "Modified", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sponsor", "Modified", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
