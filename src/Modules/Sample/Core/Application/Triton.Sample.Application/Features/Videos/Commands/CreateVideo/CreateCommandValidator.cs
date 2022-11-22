using FluentValidation;

namespace Triton.Sample.Application.Features.Videos.Commands.CreateVideo
{
    public class CreateCommandValidator : AbstractValidator<CreateVideoCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotNull().WithMessage("{Nombre} no puede ser nulo");
        }
    }
}
