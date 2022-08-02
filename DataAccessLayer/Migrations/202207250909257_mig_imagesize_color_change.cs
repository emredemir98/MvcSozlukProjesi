namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_imagesize_color_change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryColor", c => c.String(maxLength: 50));
            AlterColumn("dbo.Writers", "WriterImage", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterImage", c => c.String(maxLength: 100));
            DropColumn("dbo.Categories", "CategoryColor");
        }
    }
}
