namespace OperationsOnData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addobligation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Obligation", c => c.Double());
            AlterColumn("dbo.Books", "Title", c => c.String());
            AlterColumn("dbo.Books", "Author", c => c.String());
            AlterColumn("dbo.Books", "Type", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Type", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Books", "Author", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false, maxLength: 140));
            DropColumn("dbo.AspNetUsers", "Obligation");
        }
    }
}
