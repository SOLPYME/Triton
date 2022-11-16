using System;
using Microsoft.EntityFrameworkCore;
using Triton.Core.Domain.Common;

namespace Triton.Infrastructure.Persistence
{
	public class TritonDbContext : DbContext
	{
		public TritonDbContext(DbContextOptions<TritonDbContext> options) : base(options)
		{ }
		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer(@"Data Source=localhost;
		//		Initial Catalog=Triton; user id=sa;password=Triton2022$")
		//		.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information )
		//		.EnableSensitiveDataLogging();
		//}
		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			foreach(var _entry in ChangeTracker.Entries<BaseDomainModel>())
			{
				switch (_entry.State)
				{
					case EntityState.Added:
						_entry.Entity.CreatedDate = DateTime.Now;
						_entry.Entity.CreatedBy = "SYSTEM";
						break;
					case EntityState.Modified:
						_entry.Entity.LastModifiedDate = DateTime.Now;
						_entry.Entity.LastModifiedBy = "SYSTEM";
						break;
				}
			}
			return base.SaveChangesAsync(cancellationToken);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{ }
	}
}

