namespace CompanyDemo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class project_entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chiefs",
                c => new
                    {
                        ChiefId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Workplace = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ChiefId);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Workplace = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.DirectorId);
            
            CreateTable(
                "dbo.ProjectManagers",
                c => new
                    {
                        ProjectManagerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Workplace = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Director_DirectorId = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectManagerId)
                .ForeignKey("dbo.Directors", t => t.Director_DirectorId)
                .Index(t => t.Director_DirectorId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Manager_ProjectManagerId = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.ProjectManagers", t => t.Manager_ProjectManagerId)
                .Index(t => t.Manager_ProjectManagerId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false),
                        Description = c.String(),
                        Project_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId)
                .ForeignKey("dbo.TeamLeads", t => t.TeamId)
                .Index(t => t.TeamId)
                .Index(t => t.Project_ProjectId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Position = c.Int(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Workplace = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Team_TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Teams", t => t.Team_TeamId)
                .Index(t => t.Team_TeamId);
            
            CreateTable(
                "dbo.TeamLeads",
                c => new
                    {
                        TeamLeadId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Workplace = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.TeamLeadId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "TeamId", "dbo.TeamLeads");
            DropForeignKey("dbo.Teams", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Employees", "Team_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Projects", "Manager_ProjectManagerId", "dbo.ProjectManagers");
            DropForeignKey("dbo.ProjectManagers", "Director_DirectorId", "dbo.Directors");
            DropIndex("dbo.Employees", new[] { "Team_TeamId" });
            DropIndex("dbo.Teams", new[] { "Project_ProjectId" });
            DropIndex("dbo.Teams", new[] { "TeamId" });
            DropIndex("dbo.Projects", new[] { "Manager_ProjectManagerId" });
            DropIndex("dbo.ProjectManagers", new[] { "Director_DirectorId" });
            DropTable("dbo.TeamLeads");
            DropTable("dbo.Employees");
            DropTable("dbo.Teams");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectManagers");
            DropTable("dbo.Directors");
            DropTable("dbo.Chiefs");
        }
    }
}
