using Microsoft.AspNetCore.Identity;

namespace Triton.Identity.Infrastructure.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido1 { get; set; } = string.Empty;
        public string Apellido2 { get; set; } = string.Empty;
    }
}
