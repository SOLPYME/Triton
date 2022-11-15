using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Triton.Identity.Configurations;
using Triton.Identity.Models;

namespace Triton.Identity
{
    public class TritonDbContext : IdentityDbContext<ApplicationUser>
    {
        public TritonDbContext(DbContextOptions<TritonDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }

    }
}
