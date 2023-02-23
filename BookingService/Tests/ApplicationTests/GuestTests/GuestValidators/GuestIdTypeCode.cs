using Application.Guests.DTOs;
using Application.Guests.Validators;
using FluentValidation.TestHelper;
using System.ComponentModel.DataAnnotations;


namespace ApplicationTests.GuestTests.GuestValidators
{
    public class GuestIdTypeCode
    {
        //IDTypeCode

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void ValidarIdTypeCodeCorreto(int type)
        {
            var guestTest = new GuestDto
            {
                IdTypeCode = type
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldNotHaveValidationErrorFor(x => x.IdTypeCode);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        public void ValidarIdTypeCodeMaiorQue1OuMenorQue0(int type)
        {
            var guestTest = new GuestDto
            {
                IdTypeCode = type
            };
            var valid = new GuestValidator();
            var result = valid.TestValidate(guestTest);
            result.ShouldHaveValidationErrorFor(x => x.IdTypeCode);
        }
    }
}