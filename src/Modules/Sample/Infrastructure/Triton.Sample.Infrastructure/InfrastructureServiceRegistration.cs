using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Triton.Common.EMail.Contracts.Infrastructure;
using Triton.Common.EMail.Models;
using Triton.Core.Infrastructure.Email;
using Triton.Sample.Application.Contracts.Persistence;
using Triton.Sample.Infrastructure.Persistence;
using Triton.Sample.Infrastructure.Repository;

namespace Triton.Sample.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<SampleDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TritonConnectionString"))
            );
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(Core.Application.Contracts.Persistence.IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<IStreamerRepository, StreamerRepository>();
            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }

    }
}
