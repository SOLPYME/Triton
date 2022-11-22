using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Triton.Core.Application.Exceptions;
using Triton.Sample.Application.Contracts.Persistence;
using Triton.Sample.Domain;

namespace Triton.Sample.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteStreamerCommandHandler : IRequestHandler<DeleteStreamerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IStreamerRepository _streamerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteStreamerCommandHandler> _logger;

        public DeleteStreamerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteStreamerCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteStreamerCommand request, CancellationToken cancellationToken)
        {
            var _streamerToDelete = await _unitOfWork.StreamerRepository.GetEntityByIdAsync(request.Id);

            if (_streamerToDelete == null)
            {
                _logger.LogError($"{request.Id} streamer no existe en el sistema");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }
            _unitOfWork.StreamerRepository.DeleteEntity(_streamerToDelete);
            await _unitOfWork.Complete();
            _logger.LogInformation($"El {request.Id} streamer fue eliminado con exito");
            return Unit.Value;
        }
    }
}
