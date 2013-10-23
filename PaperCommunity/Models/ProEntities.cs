using PaperCommunity.Migrations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
namespace PaperCommunity.Models
{
    public class ProEntities : DbContext
    {
        public ProEntities() : base("ProEntities")
        {
            //System.Data.Entity.Database.SetInitializer(new DontDropDbJustCreateTablesIfModelChanged<PaperCommunity.Models.ProEntities>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProEntities, Configuration>());
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<GamingSession> GamingSessions { get; set; }
        public DbSet<Game> Games { get; set; }

        public void Detach(object entity)
        {
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;
            objectContext.Detach(entity);
        }

        //Push functions push the objects into the database if they are not found
        public Team pushTeam(Team Team)
        {
            Team DBTeam = Teams.Find(Team.Name);

            if (DBTeam == null)
            {
                Teams.Add(Team);
                return Team;
            }
            else
            {
                return DBTeam;
            }
        }

        public Player pushPlayer(Player Player)
        {
            Player DBPlayer = Players.Find(Player.Username);
            if ( DBPlayer== null)
            {
                Players.Add(Player);
                return Player;
            }
            else
            {
                return DBPlayer;
            }
        }


    }
}
