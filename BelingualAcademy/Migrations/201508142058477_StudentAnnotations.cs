namespace BelingualAcademy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Name", c => c.String());
        }
    }
}
