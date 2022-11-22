using FluentValidation;
using Triton.Sample.Application.Features.Directors.Commands.CreateDirector;

namespace Triton.Sample.Application.Features.Videos.Commands.UpdateVideo
{
    public class UpdateCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public UpdateCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotNull().WithMessage("{Nombre} no puede ser nulo");
        }
    }
}
