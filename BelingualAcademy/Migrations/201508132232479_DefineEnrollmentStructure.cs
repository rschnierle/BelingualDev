namespace BelingualAcademy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefineEnrollmentStructure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassRooms",
                c => new
                    {
                        ClassRoomID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ClassRoomID);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        TeacherID = c.Int(nullable: false),
                        Period = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.GroupID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ClassRoomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassID)
                .ForeignKey("dbo.ClassRooms", t => t.ClassRoomID, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID)
                .Index(t => t.ClassRoomID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Groups", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Classes", "GroupID", "dbo.Groups");
            DropForeignKey("dbo.Classes", "ClassRoomID", "dbo.ClassRooms");
            DropIndex("dbo.Classes", new[] { "ClassRoomID" });
            DropIndex("dbo.Classes", new[] { "GroupID" });
            DropIndex("dbo.Groups", new[] { "TeacherID" });
            DropIndex("dbo.Groups", new[] { "CourseID" });
            DropTable("dbo.Classes");
            DropTable("dbo.Groups");
            DropTable("dbo.ClassRooms");
        }
    }
}
