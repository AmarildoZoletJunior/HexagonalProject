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
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ValidarMaintenanceCorreto(bool decisao)
        {
            var RoomTest = new RoomDto
            {
                InMaintenance = decisao
            };
            var valid = new RoomValidator();
            var result = valid.TestValidate(RoomTest);
            result.ShouldNotHaveValidationErrorFor(x => x.InMaintenance);
        }

    }
}