using Application.Guests.DTOs;
using Application.Guests.Validators;
using FluentValidation.TestHelper;
using System.ComponentModel.DataAnnotations;


namespace ApplicationTests.GuestValidators
{
    public class GuestSurname
    {

        //Surname
        [Fact]
        public void ValidarSobrenomeCorreto()
        {
            var guestTest = new GuestDto
            {
                Surname = "Junior"
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldNotHaveValidationErrorFor(x => x.Surname);
        }

        [Fact]
        public void ValidarSobrenomeCom3Caracteres()
        {
            var guestTest = new GuestDto
            {
                Surname = "Jun"
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldNotHaveValidationErrorFor(x => x.Surname);
        }

        [Fact]
        public void ValidarSobrenomeComMenosDe3Caracteres()
        {
            var guestTest = new GuestDto
            {
                Surname = "Ju"
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldHaveValidationErrorFor(x => x.Surname);
        }

        [Fact]
        public void ValidarSobrenomeNull()
        {
            var guestTest = new GuestDto
            {
                Surname = null
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldHaveValidationErrorFor(x => x.Surname);
        }

        [Fact]
        public void ValidarSobrenomeEmpty()
        {
            var guestTest = new GuestDto
            {
                Surname = ""
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldHaveValidationErrorFor(x => x.Surname);
        }
    }
}