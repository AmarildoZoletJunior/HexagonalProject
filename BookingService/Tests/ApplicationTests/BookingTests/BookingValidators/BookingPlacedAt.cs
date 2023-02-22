using Application.Booking.DTOs;
using Application.Booking.Validators;
using Application.Guests.DTOs;
using Application.Guests.Validators;
using Application.Room.DTOs;
using Application.Room.Validators;
using FluentValidation.TestHelper;
using System.ComponentModel.DataAnnotations;


namespace ApplicationTests.BookingTests.BookingValidators
{
    public class BookingPlacedAt
    {
        [Fact]
        public void ValidarBookingPlacedAtCorreto()
        {
            var BookingTest = new BookingDto
            {
                 PlacedAt = DateTime.Now,
                 End = DateTime.Now.AddDays(7),
                 Start = DateTime.Now.AddHours(1)
            };
            var valid = new BookingValidator();
            var result = valid.TestValidate(BookingTest);
            result.ShouldNotHaveValidationErrorFor(x => x.End);
        }

        [Fact]
        public void ValidarBookingPlacedAtMaiorQueEnd()
        {
            var BookingTest = new BookingDto
            {
                PlacedAt = DateTime.Now.AddDays(7),
                End = DateTime.Now,
            };
            var valid = new BookingValidator();
            var result = valid.TestValidate(BookingTest);
            result.ShouldHaveValidationErrorFor(x => x.End);
        }


        [Fact]
        public void ValidarBookingPlacedAtMaiorQueStart()
        {
            var BookingTest = new BookingDto
            {
                PlacedAt = DateTime.Now.AddDays(7),
                Start = DateTime.Now,
            };
            var valid = new BookingValidator();
            var result = valid.TestValidate(BookingTest);
            result.ShouldHaveValidationErrorFor(x => x.End);
        }
    }
}