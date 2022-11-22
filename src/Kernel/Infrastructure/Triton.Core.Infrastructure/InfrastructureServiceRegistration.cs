using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Triton.Common.EMail.Contracts.Infrastructure;
using Triton.Common.EMail.Models;
using Triton.Core.Application.Contracts.Persistence;
using Triton.Core.Infrastructure.Email;
using Triton.Core.Infrastructure.Persistence;
using Triton.Core.Infrastructure.Repository;

namespace Triton.Core.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<TritonDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TritonConnectionString"))
            );
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }

    }
}
