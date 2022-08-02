namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _mig_message_readstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageReadStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageReadStatus");
        }
    }
}
