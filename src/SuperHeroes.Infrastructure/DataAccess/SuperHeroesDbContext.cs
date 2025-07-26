using Microsoft.EntityFrameworkCore;
using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Infrastructure.DataAccess
{
    public class SuperHeroesDbContext : DbContext
    {
        public SuperHeroesDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroPower>()
                .HasKey(hp => new { hp.HeroId, hp.PowerId });

            modelBuilder.Entity<HeroPower>()
                .HasOne(hp => hp.SuperHero)
                .WithMany(hp => hp.HeroesPowers)
                .HasForeignKey(hp => hp.HeroId);

            modelBuilder.Entity<HeroPower>()
                .HasOne(hp => hp.SuperPower)
                .WithMany(hp => hp.HeroesPowers)
                .HasForeignKey(hp => hp.PowerId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<SuperPower> SuperPowers { get; set; }
        public DbSet<HeroPower> HeroesPowers { get; set; }
    }
}
