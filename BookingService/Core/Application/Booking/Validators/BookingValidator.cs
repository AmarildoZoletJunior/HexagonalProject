using Application.Booking.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking.Validators
{
    public class BookingValidator : AbstractValidator<BookingDto>
    {
        public BookingValidator()
        {
            RuleFor(x => x.RoomId).NotNull().WithMessage("A RoomId não pode ser nula").NotEmpty().WithMessage("A RoomId não pode ser vazia");
            RuleFor(x => x.GuestId).NotNull().WithMessage("A GuestId não pode ser nula").NotEmpty().WithMessage("A GuestId não pode ser vazia");
            RuleFor(x => x.End).GreaterThan(x => x.Start).WithMessage("A data de saida não pode ser menor ou igual a data de entrada").GreaterThan (x => x.PlacedAt).WithMessage("A data de saida não pode ser menor que a data de criação");
            RuleFor(x => x.Start).GreaterThan(x => x.PlacedAt).WithMessage("A data de entrada não pode ser menor ou igual a data de criação");
        }
    }
}
