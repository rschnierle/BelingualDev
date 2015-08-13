namespace BelingualAcademy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefineTeacherProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(),
                        Phone = c.String(),
                        StreetAddress = c.String(),
                        Suburb = c.String(),
                        PostalCode = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Gender = c.Int(nullable: false),
                        BirthPlace = c.String(),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teachers");
        }
    }
}
