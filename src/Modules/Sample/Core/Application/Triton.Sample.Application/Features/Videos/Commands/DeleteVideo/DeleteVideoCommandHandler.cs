using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Triton.Core.Application.Exceptions;
using Triton.Sample.Application.Contracts.Persistence;
using Triton.Sample.Domain;

namespace Triton.Sample.Application.Features.Videos.Commands.DeleteVideo
{
    public class DeleteVideoCommandHandler : IRequestHandler<DeleteVideoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteVideoCommandHandler> _logger;

        public DeleteVideoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteVideoCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteVideoCommand request, CancellationToken cancellationToken)
        {
            var _videoToDelete = await _unitOfWork.VideoRepository.GetEntityByIdAsync(request.Id);

            if (_videoToDelete == null)
            {
                _logger.LogError($"{request.Id} video no existe en el sistema");
                throw new NotFoundException(nameof(Video), request.Id);
            }
            _unitOfWork.VideoRepository.DeleteEntity(_videoToDelete);
            await _unitOfWork.Complete();
            _logger.LogInformation($"El {request.Id} video fue eliminado con exito");
            return Unit.Value;
        }
    }
}
