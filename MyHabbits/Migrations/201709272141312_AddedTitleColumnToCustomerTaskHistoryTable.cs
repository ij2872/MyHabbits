namespace MyHabbits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTitleColumnToCustomerTaskHistoryTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerTaskHistories", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerTaskHistories", "Title");
        }
    }
}
