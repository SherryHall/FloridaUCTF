namespace FloridaUCTF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateCode = c.String(nullable: false, maxLength: 2),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.StateCode);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.States");
        }
    }
}
