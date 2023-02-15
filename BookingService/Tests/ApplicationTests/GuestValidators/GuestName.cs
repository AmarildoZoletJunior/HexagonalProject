using Application.Guests.DTOs;
using Application.Guests.Validators;
using FluentValidation.TestHelper;
using System.ComponentModel.DataAnnotations;


namespace ApplicationTests.GuestValidators
{
    public class GuestName
    {


        //Nome

        [Fact]
        public void ValidarNomeCorreto()
        {
            var guestTest = new GuestDto
            {
                Name = "Amarildo"
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void ValidarNomeCom3Caracteres()
        {
            var guestTest = new GuestDto
            {
                Name = "ass"
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void ValidarNomeComMenosDe3Caracteres()
        {
            var guestTest = new GuestDto
            {
                Name = "as"
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void ValidarNomeNull()
        {
            var guestTest = new GuestDto
            {
                Name = null
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void ValidarNomeEmpty()
        {
            var guestTest = new GuestDto
            {
                Name = ""
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }
    }
}