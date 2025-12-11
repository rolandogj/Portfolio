namespace Portfolio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "StudentProfile_Id", "dbo.StudentProfiles");
            DropIndex("dbo.Projects", new[] { "StudentProfile_Id" });
            RenameColumn(table: "dbo.Projects", name: "StudentProfile_Id", newName: "StudentProfileId");
            AddColumn("dbo.Educations", "Degree", c => c.String());
            AlterColumn("dbo.Projects", "StudentProfileId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "StudentProfileId");
            AddForeignKey("dbo.Projects", "StudentProfileId", "dbo.StudentProfiles", "Id", cascadeDelete: true);
            DropColumn("dbo.Educations", "Degrre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Educations", "Degrre", c => c.String());
            DropForeignKey("dbo.Projects", "StudentProfileId", "dbo.StudentProfiles");
            DropIndex("dbo.Projects", new[] { "StudentProfileId" });
            AlterColumn("dbo.Projects", "StudentProfileId", c => c.Int());
            DropColumn("dbo.Educations", "Degree");
            RenameColumn(table: "dbo.Projects", name: "StudentProfileId", newName: "StudentProfile_Id");
            CreateIndex("dbo.Projects", "StudentProfile_Id");
            AddForeignKey("dbo.Projects", "StudentProfile_Id", "dbo.StudentProfiles", "Id");
        }
    }
}
