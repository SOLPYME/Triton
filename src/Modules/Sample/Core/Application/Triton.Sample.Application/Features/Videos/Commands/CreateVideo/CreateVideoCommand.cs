using MediatR;

namespace Triton.Sample.Application.Features.Videos.Commands.CreateVideo
{
    public class CreateVideoCommand : IRequest<int>
    {
        public string Nombre { get; set; } = string.Empty;

        public int StreamerId { get; set; }
    }
}
