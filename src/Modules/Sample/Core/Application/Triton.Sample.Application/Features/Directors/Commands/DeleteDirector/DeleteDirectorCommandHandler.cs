using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Triton.Core.Application.Exceptions;
using Triton.Sample.Application.Contracts.Persistence;
using Triton.Sample.Domain;

namespace Triton.Sample.Application.Features.Streamers.Commands.DeleteStreamer
{
    public class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteDirectorCommandHandler> _logger;

        public DeleteDirectorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteDirectorCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
        {
            var _directorToDelete = await _unitOfWork.DirectorRepository.GetEntityByIdAsync(request.Id);

            if (_directorToDelete == null)
            {
                _logger.LogError($"{request.Id} director no existe en el sistema");
                throw new NotFoundException(nameof(Streamer), request.Id);
            }
            _unitOfWork.DirectorRepository.DeleteEntity(_directorToDelete);
            await _unitOfWork.Complete();
            _logger.LogInformation($"El {request.Id} director fue eliminado con exito");
            return Unit.Value;
        }
    }
}
