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
    public class BookingEnd
    {
        [Fact]
        public void ValidarBookingEndCorreto()
        {
            var BookingTest = new BookingDto
            {
                End = DateTime.Now.AddDays(2),
                Start = DateTime.Now,
            };
            var valid = new BookingValidator();
            var result = valid.TestValidate(BookingTest);
            result.ShouldNotHaveValidationErrorFor(x => x.End);
        }


        [Fact]
        public void ValidarBookingEndComADataDeAgora()
        {
            var BookingTest = new BookingDto
            {
                End = DateTime.Now,
          
            };
            var valid = new BookingValidator();
            var result = valid.TestValidate(BookingTest);
            result.ShouldHaveValidationErrorFor(x => x.End);
        }

        [Fact]
        public void ValidarBookingEndMenorQuePlacedAt()
        {
            var BookingTest = new BookingDto
            {
                End = DateTime.Now,
                PlacedAt = DateTime.Now.AddDays(2),
            };
            var valid = new BookingValidator();
            var result = valid.TestValidate(BookingTest);
            result.ShouldHaveValidationErrorFor(x => x.End);
        }

        [Fact]
        public void ValidarBookingEndMenorQueStart()
        {
            var BookingTest = new BookingDto
            {
                End = DateTime.Now,
                Start = DateTime.Now.AddDays(2),
            };
            var valid = new BookingValidator();
            var result = valid.TestValidate(BookingTest);
            result.ShouldHaveValidationErrorFor(x => x.End);
        }

    }
}