namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _mig_admin_encrypt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminUserNameEncrypt", c => c.String());
            AddColumn("dbo.Admins", "AdminPasswordEncrypt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminPasswordEncrypt");
            DropColumn("dbo.Admins", "AdminUserNameEncrypt");
        }
    }
}
