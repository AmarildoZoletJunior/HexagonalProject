using Application.Guests.DTOs;
using Application.Guests.Validators;
using Application.Room.DTOs;
using Application.Room.Validators;
using FluentValidation.TestHelper;
using System.ComponentModel.DataAnnotations;


namespace ApplicationTests.RoomTests.RoomValidators
{
    public class RoomInMaintenance
    {
        [Fact]
        public void ValidarMaintenanceCorreto()
        {
            var RoomTest = new RoomDto
            {
                InMaintenance = false
            };
            var valid = new RoomValidator();
            var result = valid.TestValidate(RoomTest);
            result.ShouldNotHaveValidationErrorFor(x => x.InMaintenance);


            var RoomTest2 = new RoomDto
            {
                InMaintenance = true
            };
            var valid2 = new RoomValidator();
            var result2 = valid2.TestValidate(RoomTest2);
            result2.ShouldNotHaveValidationErrorFor(x => x.InMaintenance);
        }

    }
}