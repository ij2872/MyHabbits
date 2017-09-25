namespace MyHabbits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedCustomerTasksTableColumns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerTasks", "CustomerTask_Id", "dbo.CustomerTasks");
            DropIndex("dbo.CustomerTasks", new[] { "CustomerTask_Id" });
            AlterColumn("dbo.CustomerTasks", "user_id", c => c.String(nullable: false));
            DropColumn("dbo.CustomerTasks", "CustomerTask_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerTasks", "CustomerTask_Id", c => c.Int());
            AlterColumn("dbo.CustomerTasks", "user_id", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomerTasks", "CustomerTask_Id");
            AddForeignKey("dbo.CustomerTasks", "CustomerTask_Id", "dbo.CustomerTasks", "Id");
        }
    }
}
