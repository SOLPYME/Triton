using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Triton.Sample.Domain;

namespace Triton.Sample.Infrastructure.Persistence
{
    public class SampleDbContext : Core.Infrastructure.Persistence.TritonDbContext
    {
        public DbSet<Streamer>? Streamers { get; set; }
        public DbSet<Video>? Videos { get; set; }
        public DbSet<Actor>? Actores { get; set; }
        public DbSet<Director>? Directores { get; set; }

        public SampleDbContext(DbContextOptions options, ILogger<SampleDbContext> logger) : base(options, logger)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streamer>()
                .HasMany(m => m.Videos)
                .WithOne(m => m.Streamer)
                .HasForeignKey(m => m.StreamerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Video>()
                .HasMany(p => p.Actores)
                .WithMany(t => t.Videos)
                .UsingEntity<VideoActor>(
                    pt => pt.HasKey(e => new { e.ActorId, e.VideoId })
                );
        }
    }
}