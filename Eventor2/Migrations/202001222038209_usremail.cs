namespace Eventor2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usremail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TicketModels", "UserEmail", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TicketModels", "UserEmail");
        }
    }
}
