using MediatR;

namespace Triton.Sample.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteDirectorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
