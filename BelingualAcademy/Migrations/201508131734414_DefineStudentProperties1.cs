namespace BelingualAcademy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefineStudentProperties1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
