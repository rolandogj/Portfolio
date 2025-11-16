namespace Portfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PortfolioDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Institution = c.String(),
                        Degrre = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        StudentProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentProfiles", t => t.StudentProfileId, cascadeDelete: true)
                .Index(t => t.StudentProfileId);
            
            CreateTable(
                "dbo.StudentProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Title = c.String(),
                        Summary = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Location = c.String(),
                        ProfileImagenUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(),
                        Position = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Description = c.String(),
                        StudentProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentProfiles", t => t.StudentProfileId, cascadeDelete: true)
                .Index(t => t.StudentProfileId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Url = c.String(),
                        ImageUrl = c.String(),
                        StudentProfile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentProfiles", t => t.StudentProfile_Id)
                .Index(t => t.StudentProfile_Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Level = c.Int(nullable: false),
                        StudentProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentProfiles", t => t.StudentProfileId, cascadeDelete: true)
                .Index(t => t.StudentProfileId);
            
            CreateTable(
                "dbo.SocialLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Platform = c.String(),
                        Url = c.String(),
                        StudentProfileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentProfiles", t => t.StudentProfileId, cascadeDelete: true)
                .Index(t => t.StudentProfileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SocialLinks", "StudentProfileId", "dbo.StudentProfiles");
            DropForeignKey("dbo.Skills", "StudentProfileId", "dbo.StudentProfiles");
            DropForeignKey("dbo.Projects", "StudentProfile_Id", "dbo.StudentProfiles");
            DropForeignKey("dbo.Experiences", "StudentProfileId", "dbo.StudentProfiles");
            DropForeignKey("dbo.Educations", "StudentProfileId", "dbo.StudentProfiles");
            DropIndex("dbo.SocialLinks", new[] { "StudentProfileId" });
            DropIndex("dbo.Skills", new[] { "StudentProfileId" });
            DropIndex("dbo.Projects", new[] { "StudentProfile_Id" });
            DropIndex("dbo.Experiences", new[] { "StudentProfileId" });
            DropIndex("dbo.Educations", new[] { "StudentProfileId" });
            DropTable("dbo.SocialLinks");
            DropTable("dbo.Skills");
            DropTable("dbo.Projects");
            DropTable("dbo.Experiences");
            DropTable("dbo.StudentProfiles");
            DropTable("dbo.Educations");
        }
    }
}
