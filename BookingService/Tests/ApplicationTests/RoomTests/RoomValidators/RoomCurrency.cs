using Application.Guests.DTOs;
using Application.Guests.Validators;
using Application.Room.DTOs;
using Application.Room.Validators;
using FluentValidation.TestHelper;
using System.ComponentModel.DataAnnotations;


namespace ApplicationTests.RoomTests.RoomValidators
{
    public class BookingStart
    {
        [Fact]
        public void ValidarCurrencyCorreto()
        {
            var RoomTest = new RoomDto
            {
                Currency = 1
            };
            var valid = new RoomValidator();
            var result = valid.TestValidate(RoomTest);
            result.ShouldNotHaveValidationErrorFor(x => x.Currency);

            var RoomTest2 = new RoomDto
            {
                Currency = 2
            };
            var valid2 = new RoomValidator();
            var result2 = valid2.TestValidate(RoomTest2);
            result2.ShouldNotHaveValidationErrorFor(x => x.Currency);

            var RoomTest3 = new RoomDto
            {
                Currency = 3
            };
            var valid3 = new RoomValidator();
            var result3 = valid3.TestValidate(RoomTest3);
            result3.ShouldNotHaveValidationErrorFor(x => x.Currency);

            var RoomTest4 = new RoomDto
            {
                Currency = 4
            };
            var valid4 = new RoomValidator();
            var result4 = valid4.TestValidate(RoomTest4);
            result4.ShouldNotHaveValidationErrorFor(x => x.Currency);
        }

        [Fact]
        public void ValidarCurrencyAcimaDe4()
        {
            var RoomTest = new RoomDto
            {
                Level = 5
            };
            var valid = new RoomValidator();
            var result = valid.TestValidate(RoomTest);
            result.ShouldHaveValidationErrorFor(x => x.Currency);
        }

        [Fact]
        public void ValidarCurrencyAbaixoDe1()
        {
            var RoomTest = new RoomDto
            {
                Level = 0
            };
            var valid = new RoomValidator();
            var result = valid.TestValidate(RoomTest);
            result.ShouldHaveValidationErrorFor(x => x.Currency);
        }

    }
}