namespace MyHabbits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTaskColumNameChangedUser_Id : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerTasks", "ApplicationUserId", c => c.String(nullable: false));
            DropColumn("dbo.CustomerTasks", "user_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerTasks", "user_id", c => c.String(nullable: false));
            DropColumn("dbo.CustomerTasks", "ApplicationUserId");
        }
    }
}
