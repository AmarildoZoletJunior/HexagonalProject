using Application.Room.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Room.Validators
{
    public class RoomValidators : AbstractValidator<RoomDto>
    {
        public RoomValidators()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("O campo Name não pode estar nulo").NotEmpty().WithMessage("O campo Name não pode estar vazio");
            RuleFor(x => x.Level).NotNull().WithMessage("O campo Level não pode estar nulo").NotEmpty().WithMessage("O campo Level não pode estar vazio");
            RuleFor(x => x.InMaintenance).NotNull().WithMessage("O campo InMaintenance não pode estar nulo").NotEmpty().WithMessage("O campo InMaintenance não pode estar vazio");
            RuleFor(x => x.Value).NotNull().WithMessage("O campo Value não pode estar nulo").NotEmpty().WithMessage("O campo Value não pode estar vazio");
            RuleFor(x => x.Currency).Custom((list, context) => {
                if (list > 4 | list < 1)
                {
                    context.AddFailure("Você só pode escolher entre 1(Dolar), 2(Euro), 3(Real), 4(Peso Argentino)");
                }
            }).NotNull().WithMessage("O campo Currency não pode estar nulo").NotEmpty().WithMessage("O campo Currency não pode estar vazio");
        }
    }
}
