namespace PaperCommunity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        DefaultTeam_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Username)
                .ForeignKey("dbo.Teams", t => t.DefaultTeam_Name)
                .Index(t => t.DefaultTeam_Name);
            
            CreateTable(
                "dbo.GamingSessions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        HomeGoals = c.Int(nullable: false),
                        AwayGoals = c.Int(nullable: false),
                        HomeTeam_Name = c.String(maxLength: 128),
                        AwayTeam_Name = c.String(maxLength: 128),
                        HomePlayer_Username = c.String(maxLength: 128),
                        AwayPlayer_Username = c.String(maxLength: 128),
                        GamingSession_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Teams", t => t.HomeTeam_Name)
                .ForeignKey("dbo.Teams", t => t.AwayTeam_Name)
                .ForeignKey("dbo.Players", t => t.HomePlayer_Username)
                .ForeignKey("dbo.Players", t => t.AwayPlayer_Username)
                .ForeignKey("dbo.GamingSessions", t => t.GamingSession_id)
                .Index(t => t.HomeTeam_Name)
                .Index(t => t.AwayTeam_Name)
                .Index(t => t.HomePlayer_Username)
                .Index(t => t.AwayPlayer_Username)
                .Index(t => t.GamingSession_id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Games", new[] { "GamingSession_id" });
            DropIndex("dbo.Games", new[] { "AwayPlayer_Username" });
            DropIndex("dbo.Games", new[] { "HomePlayer_Username" });
            DropIndex("dbo.Games", new[] { "AwayTeam_Name" });
            DropIndex("dbo.Games", new[] { "HomeTeam_Name" });
            DropIndex("dbo.Players", new[] { "DefaultTeam_Name" });
            DropForeignKey("dbo.Games", "GamingSession_id", "dbo.GamingSessions");
            DropForeignKey("dbo.Games", "AwayPlayer_Username", "dbo.Players");
            DropForeignKey("dbo.Games", "HomePlayer_Username", "dbo.Players");
            DropForeignKey("dbo.Games", "AwayTeam_Name", "dbo.Teams");
            DropForeignKey("dbo.Games", "HomeTeam_Name", "dbo.Teams");
            DropForeignKey("dbo.Players", "DefaultTeam_Name", "dbo.Teams");
            DropTable("dbo.Games");
            DropTable("dbo.GamingSessions");
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
        }
    }
}
