using Triton.Identity.Application.Models;

namespace Triton.Identity.Application.Contracts
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
