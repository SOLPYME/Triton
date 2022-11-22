using MediatR;

namespace Triton.Sample.Application.Features.Videos.Commands.DeleteVideo
{
    public class DeleteVideoCommand : IRequest
    {
        public int Id { get; set; }
    }
}
