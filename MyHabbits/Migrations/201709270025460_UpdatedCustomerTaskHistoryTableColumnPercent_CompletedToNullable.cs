namespace MyHabbits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedCustomerTaskHistoryTableColumnPercent_CompletedToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerTaskHistories", "percent_completed", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerTaskHistories", "percent_completed", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
