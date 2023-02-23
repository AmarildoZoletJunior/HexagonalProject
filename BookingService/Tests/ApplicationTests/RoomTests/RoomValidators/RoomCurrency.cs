using Application.Guests.DTOs;
using Application.Guests.Validators;
using Application.Room.DTOs;
using Application.Room.Validators;
using FluentValidation.TestHelper;
using System.ComponentModel.DataAnnotations;


namespace ApplicationTests.RoomTests.RoomValidators
{
    public class RoomCurrency
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void ValidarCurrencyCorreto(int idCurrency)
        {
            var RoomTest = new RoomDto
            {
                Currency = idCurrency
            };
            var valid = new RoomValidator();
            var result = valid.TestValidate(RoomTest);
            result.ShouldNotHaveValidationErrorFor(x => x.Currency);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(0)]
        public void ValidarCurrencyAcimaOuAbaixo(int idCurrency)
        {
            var RoomTest = new RoomDto
            {
                Currency = idCurrency
            };
            var valid = new RoomValidator();
            var result = valid.TestValidate(RoomTest);
            result.ShouldHaveValidationErrorFor(x => x.Currency);
        }

    }
}