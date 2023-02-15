using Application.Guests.DTOs;
using Application.Guests.Validators;
using FluentValidation.TestHelper;
using System.ComponentModel.DataAnnotations;


namespace ApplicationTests.GuestValidators
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
        public void ValidarIDNumberFaltandoOuSemCaracteresEspecial()
        {
            var guestTest = new GuestDto
            {
                IdNumber = "10050020512"
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldHaveValidationErrorFor(x => x.IdNumber);

            var guestTest2 = new GuestDto
            {
                IdNumber = "100.500.20512"
            };
            var valid2 = new GuestValidator();
            var result2 = valid2.TestValidate(guestTest2);
            result2.ShouldHaveValidationErrorFor(x => x.IdNumber);

            var guestTest3 = new GuestDto
            {
                IdNumber = "100.500205-12"
            };
            var valid3 = new GuestValidator();
            var result3 = valid3.TestValidate(guestTest3);
            result3.ShouldHaveValidationErrorFor(x => x.IdNumber);

            var guestTest4 = new GuestDto
            {
                IdNumber = "100500.205-12"
            };
            var valid4 = new GuestValidator();
            var result4 = valid4.TestValidate(guestTest4);
            result4.ShouldHaveValidationErrorFor(x => x.IdNumber);
        }

        [Fact]
        public void ValidarIDNumberComMenosOuMaisDe11Caracteres()
        {
            var guestTestMenos = new GuestDto
            {
                IdNumber = "1005002052"
            };
            var validMenos = new GuestValidator();
            var resultMenos = validMenos.TestValidate(guestTestMenos);
            resultMenos.ShouldHaveValidationErrorFor(x => x.IdNumber);

            var guestTestMais = new GuestDto
            {
                IdNumber = "100500205223"
            };
            var validMais = new GuestValidator();
            var resultMais = validMais.TestValidate(guestTestMais);
            resultMais.ShouldHaveValidationErrorFor(x => x.IdNumber);
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

        [Fact]
        public void ValidarIDNumberComLetraENumeros()
        {
            var guestTest = new GuestDto
            {
                IdNumber = "102.125.125-as"
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldHaveValidationErrorFor(x => x.IdNumber);

            var guestTest2 = new GuestDto
            {
                IdNumber = "102.125.asd-35"
            };
            var valid2 = new GuestValidator();
            var result2 = valid2.TestValidate(guestTest2);
            result2.ShouldHaveValidationErrorFor(x => x.IdNumber);

            var guestTest3 = new GuestDto
            {
                IdNumber = "102.asd.125-35"
            };
            var valid3 = new GuestValidator();
            var result3 = valid3.TestValidate(guestTest3);
            result3.ShouldHaveValidationErrorFor(x => x.IdNumber);

            var guestTest4 = new GuestDto
            {
                IdNumber = "asd.125.125-35"
            };
            var valid4 = new GuestValidator();
            var result4 = valid4.TestValidate(guestTest4);
            result4.ShouldHaveValidationErrorFor(x => x.IdNumber);
        }
    }
}