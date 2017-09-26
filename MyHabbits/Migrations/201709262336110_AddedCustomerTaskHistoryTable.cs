namespace MyHabbits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCustomerTaskHistoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerTaskHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        task_id = c.Int(nullable: false),
                        completed_date = c.DateTime(),
                        time_completed = c.Time(nullable: false, precision: 7),
                        time_goal = c.Time(nullable: false, precision: 7),
                        is_done = c.Boolean(nullable: false),
                        percent_completed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApplicationUserId = c.String(nullable: false),
                        customer_task_Id = c.Int(),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerTasks", t => t.customer_task_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.customer_task_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerTaskHistories", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.CustomerTaskHistories", "customer_task_Id", "dbo.CustomerTasks");
            DropIndex("dbo.CustomerTaskHistories", new[] { "Customer_Id" });
            DropIndex("dbo.CustomerTaskHistories", new[] { "customer_task_Id" });
            DropTable("dbo.CustomerTaskHistories");
        }
    }
}
