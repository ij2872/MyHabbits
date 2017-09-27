namespace MyHabbits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedCustomer_taskFromCustomerTaskHistory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerTaskHistories", "customer_task_Id", "dbo.CustomerTasks");
            DropIndex("dbo.CustomerTaskHistories", new[] { "customer_task_Id" });
            DropColumn("dbo.CustomerTaskHistories", "customer_task_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerTaskHistories", "customer_task_Id", c => c.Int());
            CreateIndex("dbo.CustomerTaskHistories", "customer_task_Id");
            AddForeignKey("dbo.CustomerTaskHistories", "customer_task_Id", "dbo.CustomerTasks", "Id");
        }
    }
}
