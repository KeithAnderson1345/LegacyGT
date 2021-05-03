namespace LegacyGT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DinnerChosenSpelledCorrectly : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dinner", "DinnerChosen", c => c.Boolean(nullable: false));
            DropColumn("dbo.Dinner", "DinnerChoosen");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dinner", "DinnerChoosen", c => c.Boolean(nullable: false));
            DropColumn("dbo.Dinner", "DinnerChosen");
        }
    }
}
