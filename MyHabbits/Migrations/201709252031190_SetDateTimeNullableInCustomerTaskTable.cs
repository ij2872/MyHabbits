namespace MyHabbits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDateTimeNullableInCustomerTaskTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerTasks", "completed_date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerTasks", "completed_date", c => c.DateTime(nullable: false));
        }
    }
}
