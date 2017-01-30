namespace FloridaUCTF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Citations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CitationNumber = c.String(maxLength: 75),
                        StatuteOrdinance = c.String(maxLength: 75),
                        Description = c.String(maxLength: 400),
                        Withheld = c.Boolean(nullable: false),
                        Probation = c.Boolean(nullable: false),
                        PrivilegeRevoked = c.Boolean(nullable: false),
                        FineAmount = c.Int(nullable: false),
                        RestitutionAmount = c.Int(nullable: false),
                        CaseId = c.Int(nullable: false),
                        ActionId = c.Int(),
                        RulingId = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        CreatorId = c.String(),
                        Creator = c.String(),
                        ChangeDate = c.DateTime(nullable: false),
                        LastChangerId = c.String(),
                        Changer = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actions", t => t.ActionId)
                .ForeignKey("dbo.Cases", t => t.CaseId, cascadeDelete: true)
                .ForeignKey("dbo.Rulings", t => t.RulingId)
                .Index(t => t.CaseId)
                .Index(t => t.ActionId)
                .Index(t => t.RulingId);
            
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OffenderId = c.Int(nullable: false),
                        CaseNumber = c.String(maxLength: 75),
                        CaseDate = c.DateTime(nullable: false),
                        CaseCity = c.String(maxLength: 75),
                        CaseCounty = c.String(nullable: false, maxLength: 75),
                        BusinessName = c.String(maxLength: 100),
                        OffenderAddressId = c.Int(nullable: false),
                        OfficialContactId = c.String(maxLength: 128),
                        CreateDate = c.DateTime(nullable: false),
                        CreatorId = c.String(),
                        Creator = c.String(),
                        ChangeDate = c.DateTime(nullable: false),
                        LastChangerId = c.String(),
                        Changer = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Offenders", t => t.OffenderId, cascadeDelete: true)
                .ForeignKey("dbo.OffenderAddresses", t => t.OffenderAddressId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.OfficialContactId)
                .Index(t => t.OffenderId)
                .Index(t => t.OffenderAddressId)
                .Index(t => t.OfficialContactId);
            
            CreateTable(
                "dbo.Offenders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 75),
                        FirstName = c.String(nullable: false, maxLength: 75),
                        MiddleName = c.String(maxLength: 75),
                        DriveLicense = c.String(maxLength: 30),
                        DriveLicenseState = c.String(maxLength: 2),
                        LastAKA = c.String(maxLength: 255),
                        FirstAKA = c.String(maxLength: 255),
                        CreateDate = c.DateTime(nullable: false),
                        CreatorId = c.String(),
                        Creator = c.String(),
                        ChangeDate = c.DateTime(nullable: false),
                        LastChangerId = c.String(),
                        Changer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OffenderAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 75),
                        State = c.String(nullable: false, maxLength: 2),
                        Zip = c.String(nullable: false, maxLength: 10),
                        OffenderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Offenders", t => t.OffenderId)
                .Index(t => t.OffenderId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(nullable: false, maxLength: 75),
                        FirstName = c.String(nullable: false, maxLength: 75),
                        Title = c.String(nullable: false, maxLength: 75),
                        Jurisdiction = c.String(nullable: false, maxLength: 100),
                        WorkPhone = c.String(nullable: false, maxLength: 15),
                        WorkExtension = c.String(),
                        Address = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 75),
                        State = c.String(nullable: false, maxLength: 2),
                        Zip = c.String(nullable: false, maxLength: 10),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Rulings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Citations", "RulingId", "dbo.Rulings");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cases", "OfficialContactId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cases", "OffenderAddressId", "dbo.OffenderAddresses");
            DropForeignKey("dbo.OffenderAddresses", "OffenderId", "dbo.Offenders");
            DropForeignKey("dbo.Cases", "OffenderId", "dbo.Offenders");
            DropForeignKey("dbo.Citations", "CaseId", "dbo.Cases");
            DropForeignKey("dbo.Citations", "ActionId", "dbo.Actions");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.OffenderAddresses", new[] { "OffenderId" });
            DropIndex("dbo.Cases", new[] { "OfficialContactId" });
            DropIndex("dbo.Cases", new[] { "OffenderAddressId" });
            DropIndex("dbo.Cases", new[] { "OffenderId" });
            DropIndex("dbo.Citations", new[] { "RulingId" });
            DropIndex("dbo.Citations", new[] { "ActionId" });
            DropIndex("dbo.Citations", new[] { "CaseId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Rulings");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.OffenderAddresses");
            DropTable("dbo.Offenders");
            DropTable("dbo.Cases");
            DropTable("dbo.Citations");
            DropTable("dbo.Actions");
        }
    }
}
