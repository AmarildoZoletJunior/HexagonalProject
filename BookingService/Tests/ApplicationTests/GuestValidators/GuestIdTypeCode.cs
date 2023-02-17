using Application.Guests.DTOs;
using Application.Guests.Validators;
using FluentValidation.TestHelper;
using System.ComponentModel.DataAnnotations;


namespace ApplicationTests.GuestValidators
{
    public class GuestIdTypeCode
    {
        //IDTypeCode

        [Fact]
        public void ValidarIdTypeCodeCorreto()
        {
            var guestTest1 = new GuestDto
            {
                IdTypeCode = 1
            };
            var valid1 = new GuestValidator();
            var result1 = valid1.TestValidate(guestTest1);
            result1.ShouldNotHaveValidationErrorFor(x => x.IdTypeCode);

            var guestTest0 = new GuestDto
            {
                IdTypeCode = 2
            };
            var valid0 = new GuestValidator();
            var result0 = valid0.TestValidate(guestTest0);
            result0.ShouldNotHaveValidationErrorFor(x => x.IdTypeCode);
        }

        [Fact]
        public void ValidarIdTypeCodeMaiorQue1OuMenorQue0()
        {
            var guestTest2 = new GuestDto
            {
                IdTypeCode = 0
            };
            var valid2 = new GuestValidator();
            var result2 = valid2.TestValidate(guestTest2);
            result2.ShouldHaveValidationErrorFor(x => x.IdTypeCode);

            var guestTest = new GuestDto
            {
                IdTypeCode = 3
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldHaveValidationErrorFor(x => x.IdTypeCode);
        }
    }
}