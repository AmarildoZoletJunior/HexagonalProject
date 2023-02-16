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
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Level).NotNull().NotEmpty();
            RuleFor(x => x.InMaintenance).NotNull().NotEmpty();
            RuleFor(x => x.Value).NotNull().NotEmpty();
            RuleFor(x => x.Currency).Custom((list, context) => {
                if (list > 4 | list < 1)
                {
                    context.AddFailure("Você só pode escolher entre 1(Dolar), 2(Euro), 3(Real), 4(Peso Argentino)");
                }
            }).NotNull().NotEmpty();
        }
    }
}
