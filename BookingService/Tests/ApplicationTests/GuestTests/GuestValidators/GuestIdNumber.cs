using Application.Guests.DTOs;
using Application.Guests.Validators;
using FluentValidation.TestHelper;
using System.ComponentModel.DataAnnotations;


namespace ApplicationTests.GuestTests.GuestValidators
{
    public class GuestIdNumber
    {


        //IdNumber
        [Fact]
        public void ValidarIDNumberCorreto()
        {
            var guestTest = new GuestDto
            {
                IdNumber = "100.500.205-12"
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldNotHaveValidationErrorFor(x => x.IdNumber);
        }


        [Fact]
        public void ValidarIDNumberEmpty()
        {
            var guestTest = new GuestDto
            {
                IdNumber = ""
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldHaveValidationErrorFor(x => x.IdNumber);
        }

        [Fact]
        public void ValidarIDNumberNull()
        {
            var guestTest = new GuestDto
            {
                IdNumber = null
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldHaveValidationErrorFor(x => x.IdNumber);
        }

        [Fact]
        public void ValidarIDNumberComLetra()
        {
            var guestTest = new GuestDto
            {
                IdNumber = "asdadsadasd123"
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldHaveValidationErrorFor(x => x.IdNumber);
        }

        [Theory]
        [InlineData("10050020512")]
        [InlineData("100.500.20512")]
        [InlineData("100.500205-12")]
        [InlineData("100500.205-12")]
        public void ValidarIDNumberFaltandoOuSemCaracteresEspecial(string idNum)
        {
            var guestTest = new GuestDto
            {
                IdNumber = idNum
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldHaveValidationErrorFor(x => x.IdNumber);
        }

        [Theory]
        [InlineData("1005002052")]
        [InlineData("100500205223")]
        public void ValidarIDNumberComMenosOuMaisDe11Caracteres(string idNum)
        {
            var guestTestMenos = new GuestDto
            {
                IdNumber = idNum
            };
            var validMenos = new GuestValidator();
            var resultMenos = validMenos.TestValidate(guestTestMenos);
            resultMenos.ShouldHaveValidationErrorFor(x => x.IdNumber);
        }


        [Theory]
        [InlineData("102.125.125-as")]
        [InlineData("102.125.asd-35")]
        [InlineData("102.asd.125-35")]
        [InlineData("102.asd.125-35")]
        public void ValidarIDNumberComLetraENumeros(string idNum)
        {
            var guestTest = new GuestDto
            {
                IdNumber = idNum
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldHaveValidationErrorFor(x => x.IdNumber);
        }
    }
}