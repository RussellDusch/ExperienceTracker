using Microsoft.EntityFrameworkCore;
using ExperienceTracker.Models;

namespace ExperienceTracker.Models
{
    public class ExperienceTrackerContext : DbContext
    {
        public ExperienceTrackerContext(DbContextOptions options) :
            base(options)
        {
        }

        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Encounter> Encounters { get; set; }
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<CharacterEncounter> CharacterEncounter { get; set; }
        public DbSet<MonsterEncounter> MonsterEncounter { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterEncounter>()
                .HasKey(pe => new { pe.CharacterId, pe.EncounterId });

            modelBuilder.Entity<CharacterEncounter>()
                .HasOne(pe => pe.Character)
                .WithMany(p => p.Encounters)
                .HasForeignKey(pe => pe.CharacterId);

            modelBuilder.Entity<CharacterEncounter>()
                .HasOne(pe => pe.Encounter)
                .WithMany(p => p.PlayerCharacters)
                .HasForeignKey(pe => pe.EncounterId);

            modelBuilder.Entity<MonsterEncounter>()
                .HasKey(me => new { me.MonsterId, me.EncounterId });

            modelBuilder.Entity<MonsterEncounter>()
                .HasOne(me => me.Encounter)
                .WithMany(e => e.Monsters)
                .HasForeignKey(me => me.EncounterId);

            modelBuilder.Entity<MonsterEncounter>()
                .HasOne(me => me.Monster)
                .WithMany(m => m.Encounters)
                .HasForeignKey(me => me.MonsterId);

            modelBuilder.Entity<CampaignPlayer>()
                .HasKey(cp => new { cp.PlayerId, cp.CampaignId });

            modelBuilder.Entity<CampaignPlayer>()
                .HasOne(cp => cp.Player)
                .WithMany(p => p.Campaigns)
                .HasForeignKey(cp => cp.PlayerId);

            modelBuilder.Entity<CampaignPlayer>()
                .HasOne(cp => cp.Campaign)
                .WithMany(c => c.Players)
                .HasForeignKey(cp => cp.CampaignId);
        }

        public DbSet<ExperienceTracker.Models.CampaignPlayer> CampaignPlayer { get; set; }
    }
}
