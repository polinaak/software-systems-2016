namespace TripSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(maxLength: 50),
                        SessionKey = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Count = c.Int(nullable: false),
                        TripId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trips", t => t.TripId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.TripId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        TripId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trips", t => t.TripId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.TripId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DestinationTrips",
                c => new
                    {
                        Destination_Id = c.Int(nullable: false),
                        Trip_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Destination_Id, t.Trip_Id })
                .ForeignKey("dbo.Destinations", t => t.Destination_Id, cascadeDelete: false)
                .ForeignKey("dbo.Trips", t => t.Trip_Id, cascadeDelete: false)
                .Index(t => t.Destination_Id)
                .Index(t => t.Trip_Id);
            
            CreateTable(
                "dbo.UserDestinations",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Destination_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Destination_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: false)
                .ForeignKey("dbo.Destinations", t => t.Destination_Id, cascadeDelete: false)
                .Index(t => t.User_Id)
                .Index(t => t.Destination_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserDestinations", new[] { "Destination_Id" });
            DropIndex("dbo.UserDestinations", new[] { "User_Id" });
            DropIndex("dbo.DestinationTrips", new[] { "Trip_Id" });
            DropIndex("dbo.DestinationTrips", new[] { "Destination_Id" });
            DropIndex("dbo.Notes", new[] { "UserId" });
            DropIndex("dbo.Notes", new[] { "TripId" });
            DropIndex("dbo.Products", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "TripId" });
            DropIndex("dbo.Trips", new[] { "UserId" });
            DropForeignKey("dbo.UserDestinations", "Destination_Id", "dbo.Destinations");
            DropForeignKey("dbo.UserDestinations", "User_Id", "dbo.Users");
            DropForeignKey("dbo.DestinationTrips", "Trip_Id", "dbo.Trips");
            DropForeignKey("dbo.DestinationTrips", "Destination_Id", "dbo.Destinations");
            DropForeignKey("dbo.Notes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Notes", "TripId", "dbo.Trips");
            DropForeignKey("dbo.Products", "UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "TripId", "dbo.Trips");
            DropForeignKey("dbo.Trips", "UserId", "dbo.Users");
            DropTable("dbo.UserDestinations");
            DropTable("dbo.DestinationTrips");
            DropTable("dbo.Notes");
            DropTable("dbo.Products");
            DropTable("dbo.Users");
            DropTable("dbo.Destinations");
            DropTable("dbo.Trips");
        }
    }
}
