namespace Gazallion.MigraineManager.Data.SqlServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMedType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.__RefactorLog",
                c => new
                    {
                        OperationKey = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.OperationKey);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        StreetName = c.String(nullable: false, maxLength: 50),
                        StreetNumber = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        Region = c.String(nullable: false, maxLength: 50),
                        ZipCode = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserToken = c.String(maxLength: 50),
                        FirstName = c.Binary(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 100),
                        EmailAddress = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Diet",
                c => new
                    {
                        DietId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MedHistoryId = c.Int(nullable: false),
                        FoodItemName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.DietId)
                .ForeignKey("dbo.MedHistory", t => t.MedHistoryId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MedHistoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MedHistory",
                c => new
                    {
                        MedHistoryId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        ConditionTypeId = c.Int(nullable: false),
                        MedId = c.Int(),
                    })
                .PrimaryKey(t => t.MedHistoryId)
                .ForeignKey("dbo.ConditionType", t => t.ConditionTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Medicine", t => t.MedId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ConditionTypeId)
                .Index(t => t.MedId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ConditionType",
                c => new
                    {
                        ConditionTypeId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ConditionTypeId);
            
            CreateTable(
                "dbo.Medicine",
                c => new
                    {
                        MedId = c.Int(nullable: false, identity: true),
                        MedTypeId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.MedId);
            
            CreateTable(
                "dbo.UserMed",
                c => new
                    {
                        UserMedId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MedId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserMedId)
                .ForeignKey("dbo.Medicine", t => t.MedId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MedId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserMed", new[] { "UserId" });
            DropIndex("dbo.UserMed", new[] { "MedId" });
            DropIndex("dbo.MedHistory", new[] { "UserId" });
            DropIndex("dbo.MedHistory", new[] { "MedId" });
            DropIndex("dbo.MedHistory", new[] { "ConditionTypeId" });
            DropIndex("dbo.Diet", new[] { "UserId" });
            DropIndex("dbo.Diet", new[] { "MedHistoryId" });
            DropIndex("dbo.Address", new[] { "UserId" });
            DropForeignKey("dbo.UserMed", "UserId", "dbo.User");
            DropForeignKey("dbo.UserMed", "MedId", "dbo.Medicine");
            DropForeignKey("dbo.MedHistory", "UserId", "dbo.User");
            DropForeignKey("dbo.MedHistory", "MedId", "dbo.Medicine");
            DropForeignKey("dbo.MedHistory", "ConditionTypeId", "dbo.ConditionType");
            DropForeignKey("dbo.Diet", "UserId", "dbo.User");
            DropForeignKey("dbo.Diet", "MedHistoryId", "dbo.MedHistory");
            DropForeignKey("dbo.Address", "UserId", "dbo.User");
            DropTable("dbo.UserMed");
            DropTable("dbo.Medicine");
            DropTable("dbo.ConditionType");
            DropTable("dbo.MedHistory");
            DropTable("dbo.Diet");
            DropTable("dbo.User");
            DropTable("dbo.Address");
            DropTable("dbo.__RefactorLog");
        }
    }
}
