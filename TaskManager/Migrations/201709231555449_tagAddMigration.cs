namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using TaskManager.Models;

    public partial class tagAddMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonalTasks",
                "Tags", c =>  c.String(nullable: false, defaultValue: "task"));
            
        }
        
        public override void Down()
        {
        }
    }
}
