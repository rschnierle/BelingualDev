namespace BelingualAcademy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefineStudentProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "DateOfBirth", c => c.DateTime(nullable: false));
            DropColumn("dbo.Students", "DatOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "DatOfBirth", c => c.DateTime(nullable: false));
            DropColumn("dbo.Students", "DateOfBirth");
        }
    }
}
