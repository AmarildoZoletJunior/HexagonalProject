using Application.Guests.DTOs;
using Application.Guests.Validators;
using Application.Room.DTOs;
using Application.Room.Validators;
using FluentValidation.TestHelper;
using System.ComponentModel.DataAnnotations;


namespace ApplicationTests.RoomTests.RoomValidators
{
    public class RoomLevel
    {
        [Fact]
        public void ValidarLevelCorreto()
        {
            var RoomTest = new RoomDto
            {
                Level = 2
            };
            var valid = new RoomValidator();
            var result = valid.TestValidate(RoomTest);
            result.ShouldNotHaveValidationErrorFor(x => x.Level);
        }

    }
}