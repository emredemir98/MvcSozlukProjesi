namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _mig_writer_encrypt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterMailEncrypt", c => c.String());
            AddColumn("dbo.Writers", "WriterPasswordEncrypt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterPasswordEncrypt");
            DropColumn("dbo.Writers", "WriterMailEncrypt");
        }
    }
}
