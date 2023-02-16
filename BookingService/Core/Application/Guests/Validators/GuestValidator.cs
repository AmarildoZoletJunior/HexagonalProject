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
            RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(x => x.Surname).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull();
            RuleFor(x => x.IdTypeCode).Custom((list, context) => {
                if (list > 2 | list < 1 )
                {
                    context.AddFailure("Você só pode escolher entre 0(Passaport) ou 1(CNH)");
                }
            }).NotNull().NotEmpty();
            RuleFor(x => x.IdNumber).Matches("^\\d{3}\\.\\d{3}\\.\\d{3}-\\d{2}$").WithMessage("Cpf invalido").NotNull().WithMessage("Cpf invalido").NotEmpty().WithMessage("Cpf invalido");
        }
    }
}
