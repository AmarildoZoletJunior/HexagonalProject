using Application.Guests.DTOs;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Guests.Validators
{
    public class GuestValidator : AbstractValidator<GuestDto>
    {
        public GuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O campo Name não pode estar vazio").NotNull().WithMessage("O campo Name não pode estar nulo").MinimumLength(3).WithMessage("O campo Name deve conter no minimo 3 caracteres");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("O campo Surname não pode estar vazio").NotNull().WithMessage("O campo Surname não pode estar nulo").MinimumLength(3).WithMessage("O campo Surname deve conter no minimo 3 caracteres");
            RuleFor(x => x.Email).EmailAddress().WithMessage("O campo Email esta incorreto").NotEmpty().WithMessage("O campo Email não pode estar vazio").NotNull().WithMessage("O campo Email não pode estar nulo");
            RuleFor(x => x.IdTypeCode).Custom((list, context) => {
                if (list > 2 | list < 1 )
                {
                    context.AddFailure("Você só pode escolher entre 1(Passaport) ou 2(CNH)");
                }
            }).NotNull().WithMessage("O campo IdTypeCode não pode estar nulo").NotEmpty().WithMessage("O campo IdTypeCode não pode estar vazio");
            RuleFor(x => x.IdNumber).Matches("^\\d{3}\\.\\d{3}\\.\\d{3}-\\d{2}$").WithMessage("Cpf invalido").NotNull().WithMessage("O campo CPF campo não pode estar nulo").NotEmpty().WithMessage("O campo CPF não pode estar vazio");  
        }
    }
}
