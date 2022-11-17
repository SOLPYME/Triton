using Microsoft.Extensions.Logging;
using Triton.Sample.Domain;

namespace Triton.Sample.Infrastructure.Persistence
{
    public class SampleDbContextSeed
    {
        public static async Task SeedAsync(SampleDbContext context, ILogger<SampleDbContextSeed> logger)
        {
            if (!context.Streamers!.Any())
            {
                context.Streamers!.AddRange(GetPreconfiguredStreamer());
                await context.SaveChangesAsync();
                logger.LogInformation($"Estamos insertando nuevos records al db {context}", typeof(SampleDbContext).Name);
            }
        }
        private static IEnumerable<Streamer> GetPreconfiguredStreamer()
        {
            return new List<Streamer>
            {
                new Streamer {CreatedBy = "TritonSystem", Nombre = "Maxi HBP", Url = "http://www.hbp.com" },
                new Streamer {CreatedBy = "TritonSystem", Nombre = "Amazon VIP", Url = "http://www.amazonvip.com" },
            };
        }
    }
}
