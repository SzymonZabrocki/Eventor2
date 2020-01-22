namespace Eventor2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ticket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketModels",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TicketModels");
        }
    }
}
