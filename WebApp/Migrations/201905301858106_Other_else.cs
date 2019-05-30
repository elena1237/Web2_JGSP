namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Other_else : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriceLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                        TicketPrice = c.Single(nullable: false),
                        PassengerTypeId = c.Int(nullable: false),
                        TicketTypeId = c.Int(nullable: false),
                        CurrentValid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Departure = c.String(nullable: false),
                        DayInWeek = c.Int(nullable: false),
                        LineId = c.Int(nullable: false),
                        ScheduleType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lines", t => t.LineId, cascadeDelete: true)
                .ForeignKey("dbo.ScheduleTypes", t => t.ScheduleType_Id)
                .Index(t => t.LineId)
                .Index(t => t.ScheduleType_Id);
            
            CreateTable(
                "dbo.ScheduleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleLine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Lines", t => t.VehicleLine_Id)
                .Index(t => t.VehicleLine_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "VehicleLine_Id", "dbo.Lines");
            DropForeignKey("dbo.Schedules", "ScheduleType_Id", "dbo.ScheduleTypes");
            DropForeignKey("dbo.Schedules", "LineId", "dbo.Lines");
            DropIndex("dbo.Vehicles", new[] { "VehicleLine_Id" });
            DropIndex("dbo.Schedules", new[] { "ScheduleType_Id" });
            DropIndex("dbo.Schedules", new[] { "LineId" });
            DropTable("dbo.Vehicles");
            DropTable("dbo.ScheduleTypes");
            DropTable("dbo.Schedules");
            DropTable("dbo.PriceLists");
        }
    }
}
