﻿using FluentValidation;

namespace Triton.Sample.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotNull().WithMessage("{Nombre} no puede ser nulo");
            RuleFor(p => p.Apellido1)
                .NotNull().WithMessage("{Apellido1} no puede ser nulo");
            RuleFor(p => p.Apellido2)
                .NotNull().WithMessage("{Apellido2} no puede ser nulo");
        }
    }
}
