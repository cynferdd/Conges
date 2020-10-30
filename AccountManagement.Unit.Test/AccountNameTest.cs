using System;
using AccountManagement.Domain;
using NFluent;
using Shared.Core.Validations;
using Xunit;

namespace AccountManagement.Unit.Test
{
    public class AccountNameTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("       ")]
        public void ShouldReturnInvalid_WhenIsEmpty(string name)
        {
            Check.That(AccountName.TryCreate(name))
                .Equals(
                    Validation.Invalid<AccountName>(
                        new AccountName.IsEmptyError()));
        }

        [Theory]
        [InlineData("aze@p3")]
        [InlineData("aze/p2")]
        [InlineData("aze.p1")]
        public void ShouldReturnInvalid_WhenInvalidCharacterIsUsed(string name)
        {
            Check.That(AccountName.TryCreate(name))
                .Equals(
                    Validation.Invalid<AccountName>(
                        new AccountName.IsInvalidCharacterError()));
        }
        
        [Fact]
        public void ShouldReturnInvalid_WhenLongerThan20Characters()
        {
            Check.That(AccountName.TryCreate("123456789012345678901234567890"))
                .Equals(
                    Validation.Invalid<AccountName>(
                        new AccountName.IsInvalidLengthError()));
        }
        [Fact]
        public void ShouldReturnInvalidLengthAndCharacter_WhenLongerThan20CharactersAndContainsInvalidCharacter()
        {
            Check.That(AccountName.TryCreate("12345678901234567!@[8901234567890"))
                .Equals(
                    Validation.Invalid<AccountName>(
                        new AccountName.IsInvalidCharacterError(),
                        new AccountName.IsInvalidLengthError()));
        }

        [Fact]
        public void ShouldReturnValid_WhenNotEmptyAndCorrectSizeAndValidCharacters()
        {
            string name = "CômpteAzerty-123";
            Check.That(AccountName.TryCreate(name))
                .Equals(
                    Validation.Valid(new AccountName(name)));
        }
    }
}