namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tickets", newName: "BaseTickets");
            AddColumn("dbo.BaseTickets", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BaseTickets", "Discriminator");
            RenameTable(name: "dbo.BaseTickets", newName: "Tickets");
        }
    }
}
