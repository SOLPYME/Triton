using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Triton.Sample.Application.Contracts.Persistence;
using Triton.Sample.Domain;

namespace Triton.Sample.Application.Features.Directors.Commands.CreateDirector
{
    public class UpdateDirectorCommandHandler : IRequestHandler<UpdateDirectorCommand, int>
    {
        private readonly ILogger<UpdateDirectorCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDirectorCommandHandler(ILogger<UpdateDirectorCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
        {
            var directorEntity = _mapper.Map<Director>(request);

            _unitOfWork.Repository<Director>().AddEntity(directorEntity);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
            {
                _logger.LogError("No se inserto el record del director");
                throw new Exception("No se pudo insertar el record del director");
            }
            return directorEntity.Id;
        }
    }
}
