namespace MyHabbits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCustomerTaskTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        time_completed = c.Time(nullable: false, precision: 7),
                        time_goal = c.Time(nullable: false, precision: 7),
                        is_done = c.Boolean(nullable: false),
                        completed_date = c.DateTime(nullable: false),
                        user_id = c.Int(nullable: false),
                        customer_Id = c.Int(),
                        CustomerTask_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.customer_Id)
                .ForeignKey("dbo.CustomerTasks", t => t.CustomerTask_Id)
                .Index(t => t.customer_Id)
                .Index(t => t.CustomerTask_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerTasks", "CustomerTask_Id", "dbo.CustomerTasks");
            DropForeignKey("dbo.CustomerTasks", "customer_Id", "dbo.Customers");
            DropIndex("dbo.CustomerTasks", new[] { "CustomerTask_Id" });
            DropIndex("dbo.CustomerTasks", new[] { "customer_Id" });
            DropTable("dbo.CustomerTasks");
        }
    }
}
