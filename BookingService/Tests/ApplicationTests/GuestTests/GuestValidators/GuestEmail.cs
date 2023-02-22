using Application.Guests.DTOs;
using Application.Guests.Validators;
using FluentValidation.TestHelper;
using System.ComponentModel.DataAnnotations;


namespace ApplicationTests.GuestTests.GuestValidators
{
    public class Room
    {

        //Email
        [Fact]
        public void ValidarEmailCorreto()
        {
            var guestTest = new GuestDto
            {
                Email = "amarildozj@gmail.com"
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldNotHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void ValidarEmailIncorreto()
        {
            var guestTest = new GuestDto
            {
                Email = "Amarildo"
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void ValidarEmailNulo()
        {
            var guestTest = new GuestDto
            {
                Email = null
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void ValidarEmailEmpty()
        {
            var guestTest = new GuestDto
            {
                Email = ""
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }
    }
}