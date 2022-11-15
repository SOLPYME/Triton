using Triton.Core.Application.Models;

namespace Triton.Core.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
