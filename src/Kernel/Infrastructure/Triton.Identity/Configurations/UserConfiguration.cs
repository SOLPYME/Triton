using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Triton.Identity.Models;

namespace Triton.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                    new ApplicationUser
                    {
                        Id = "f284b3fd-f2cf-476e-a9b6-6560689cc48c",
                        Email = "admin@locahost.com",
                        NormalizedEmail = "ADMIN@LOCALHOST.COM",
                        Nombre = "Administrador",
                        Apellido1 = "Triton",
                        Apellido2 = "V1",
                        UserName = "administrador",
                        NormalizedUserName = "ADMINISTRADOR",
                        PasswordHash = hasher.HashPassword(null, "Triton2022$"),
                        EmailConfirmed = true,
                    },
                    new ApplicationUser
                    {
                        Id = "294d249b-9b57-48c1-9689-11a91abb6447",
                        Email = "juanperez@locahost.com",
                        NormalizedEmail = "JUANPEREZ@LOCALHOST.COM",
                        Nombre = "Juan",
                        Apellido1 = "Perez",
                        Apellido2 = "Lopez",
                        UserName = "juanperez",
                        NormalizedUserName = "JUANPEREZ",
                        PasswordHash = hasher.HashPassword(null, "Triton2022$"),
                        EmailConfirmed = true,
                    }
                );
        }
    }
}
