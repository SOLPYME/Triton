using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Triton.Identity.Infrastructure.Configurations;
using Triton.Identity.Infrastructure.Models;

namespace Triton.Identity.Infrastructure.Persistence
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly ILogger<IdentityDbContext> _logger;
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options, ILogger<IdentityDbContext> logger) : base(options)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            _logger.LogInformation($"Generated Role Configuration");
            builder.ApplyConfiguration(new UserConfiguration());
            _logger.LogInformation($"Generated User Configuration");
            builder.ApplyConfiguration(new UserRoleConfiguration());
            _logger.LogInformation($"Generated UserRole Configuration");
        }
    }
}
