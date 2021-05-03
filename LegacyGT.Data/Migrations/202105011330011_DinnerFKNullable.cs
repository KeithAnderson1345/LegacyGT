namespace LegacyGT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DinnerFKNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dinner", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.Dinner", "VolunteerId", "dbo.Volunteer");
            DropIndex("dbo.Dinner", new[] { "PlayerId" });
            DropIndex("dbo.Dinner", new[] { "VolunteerId" });
            AlterColumn("dbo.Dinner", "PlayerId", c => c.Int());
            AlterColumn("dbo.Dinner", "VolunteerId", c => c.Int());
            CreateIndex("dbo.Dinner", "PlayerId");
            CreateIndex("dbo.Dinner", "VolunteerId");
            AddForeignKey("dbo.Dinner", "PlayerId", "dbo.Player", "PlayerId");
            AddForeignKey("dbo.Dinner", "VolunteerId", "dbo.Volunteer", "VolunteerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dinner", "VolunteerId", "dbo.Volunteer");
            DropForeignKey("dbo.Dinner", "PlayerId", "dbo.Player");
            DropIndex("dbo.Dinner", new[] { "VolunteerId" });
            DropIndex("dbo.Dinner", new[] { "PlayerId" });
            AlterColumn("dbo.Dinner", "VolunteerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Dinner", "PlayerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Dinner", "VolunteerId");
            CreateIndex("dbo.Dinner", "PlayerId");
            AddForeignKey("dbo.Dinner", "VolunteerId", "dbo.Volunteer", "VolunteerId", cascadeDelete: true);
            AddForeignKey("dbo.Dinner", "PlayerId", "dbo.Player", "PlayerId", cascadeDelete: true);
        }
    }
}
