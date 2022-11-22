using Triton.Common.EMail.Models;

namespace Triton.Common.EMail.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
