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
    public class BookingStart
    {
        [Fact]
        public void ValidarBookingStartCorreto()
        {
            var BookingTest = new BookingDto
            {
                End = DateTime.Now.AddDays(7),
                PlacedAt = DateTime.Now,
                Start = DateTime.Now.AddDays(2),
            };
            var valid = new BookingValidator();
            var result = valid.TestValidate(BookingTest);
            result.ShouldNotHaveValidationErrorFor(x => x.Start);
        }

        [Fact]
        public void ValidarBookingStartMenorQuePlacedAt()
        {
            var BookingTest = new BookingDto
            {
                 PlacedAt = DateTime.Now.AddDays(2),
                  Start = DateTime.Now,
            };
            var valid = new BookingValidator();
            var result = valid.TestValidate(BookingTest);
            result.ShouldHaveValidationErrorFor(x => x.Start);
        }

        [Fact]
        public void ValidarBookingStartMaiorQueEnd()
        {
            var BookingTest = new BookingDto
            {
                End = DateTime.Now,
                Start = DateTime.Now.AddDays(2),
            };
            var valid = new BookingValidator();
            var result = valid.TestValidate(BookingTest);
            result.ShouldHaveValidationErrorFor(x => x.Start);
        }
    }
}