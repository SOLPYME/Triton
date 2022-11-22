using MediatR;

namespace Triton.Sample.Application.Features.Videos.Commands.UpdateVideo
{
    public class UpdateVideoCommand : IRequest<int>
    {
        public string Nombre { get; set; } = string.Empty;

        public int StreamerId { get; set; }
    }
}
