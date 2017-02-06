namespace FloridaUCTF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBlankSeedRecords : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Citations", "ActionId", "dbo.Actions");
            DropForeignKey("dbo.Citations", "RulingId", "dbo.Rulings");
            DropIndex("dbo.Citations", new[] { "ActionId" });
            DropIndex("dbo.Citations", new[] { "RulingId" });
            AlterColumn("dbo.Citations", "ActionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Citations", "RulingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Citations", "ActionId");
            CreateIndex("dbo.Citations", "RulingId");
            AddForeignKey("dbo.Citations", "ActionId", "dbo.Actions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Citations", "RulingId", "dbo.Rulings", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Citations", "RulingId", "dbo.Rulings");
            DropForeignKey("dbo.Citations", "ActionId", "dbo.Actions");
            DropIndex("dbo.Citations", new[] { "RulingId" });
            DropIndex("dbo.Citations", new[] { "ActionId" });
            AlterColumn("dbo.Citations", "RulingId", c => c.Int());
            AlterColumn("dbo.Citations", "ActionId", c => c.Int());
            CreateIndex("dbo.Citations", "RulingId");
            CreateIndex("dbo.Citations", "ActionId");
            AddForeignKey("dbo.Citations", "RulingId", "dbo.Rulings", "Id");
            AddForeignKey("dbo.Citations", "ActionId", "dbo.Actions", "Id");
        }
    }
}
