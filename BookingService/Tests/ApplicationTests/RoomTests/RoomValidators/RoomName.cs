using Application.Guests.DTOs;
using Application.Guests.Validators;
using Application.Room.DTOs;
using Application.Room.Validators;
using FluentValidation.TestHelper;
using System.ComponentModel.DataAnnotations;


namespace ApplicationTests.RoomTests.RoomValidators
{
    public class RoomName
    {
        [Fact]
        public void ValidarNameCorreto()
        {
            var RoomTest = new RoomDto
            {
                Name = "Suite com banheiro"
            };
            var valid = new RoomValidator();
            var result = valid.TestValidate(RoomTest);
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }
        [Fact]
        public void ValidarNameEmpty()
        {
            var RoomTest = new RoomDto
            {
                Name = ""
            };
            var valid = new RoomValidator();
            var result = valid.TestValidate(RoomTest);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }
        [Fact]
        public void ValidarNameNull()
        {
            var RoomTest = new RoomDto
            {
                Name = null
            };
            var valid = new RoomValidator();
            var result = valid.TestValidate(RoomTest);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

    }
}