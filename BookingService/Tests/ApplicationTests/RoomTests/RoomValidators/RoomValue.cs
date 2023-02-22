using Application.Guests.DTOs;
using Application.Guests.Validators;
using Application.Room.DTOs;
using Application.Room.Validators;
using FluentValidation.TestHelper;
using System.ComponentModel.DataAnnotations;


namespace ApplicationTests.RoomTests.RoomValidators
{
    public class RoomValue
    {
        [Fact]
        public void ValidarValueCorreto()
        {
            var RoomTest = new RoomDto
            {
                Value = 10
            };
            var valid = new RoomValidator();
            var result = valid.TestValidate(RoomTest);
            result.ShouldHaveValidationErrorFor(x => x.Level);
        }

        [Fact]
        public void ValidarValueAbaixoDe10()
        {
            var RoomTest = new RoomDto
            {
                Value = 5
            };
            var valid = new RoomValidator();
            var result = valid.TestValidate(RoomTest);
            result.ShouldHaveValidationErrorFor(x => x.Level);
        }

    }
}