namespace LegacyGT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDonationToSponsor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sponsor", "Donation", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sponsor", "Donation");
        }
    }
}
