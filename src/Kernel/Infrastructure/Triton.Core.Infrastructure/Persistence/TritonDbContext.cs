using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Triton.Core.Domain.Common;

namespace Triton.Core.Infrastructure.Persistence
{
    public class TritonDbContext : DbContext
    {
        private readonly ILogger _logger;

        public TritonDbContext(DbContextOptions options, ILogger<TritonDbContext> logger) : base(options) 
        { 
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "TritonSystem";
                        _logger.LogInformation($"Added register of Entity ({entry}) at {entry.Entity.CreatedDate}");
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "TritonSystem";
                        _logger.LogInformation($"Updated register of Entity ({entry}) at {entry.Entity.LastModifiedDate}");
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}