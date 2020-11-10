using System.Collections.Generic;
using System.Text.RegularExpressions;
using Shared.Core;
using Shared.Core.DomainModeling;
using Shared.Core.Validations;

namespace AccountManagement.Domain
{
    public class AccountName : StringBasedValueObject
    {
        public AccountName(string name) : base(name)
        {
            Validate(name).EnsureIsValid();
        }

        public static Validation<AccountName> TryCreate(string name) => 
            Validate(name).ToValidation(() => new AccountName(name));

        private static IReadOnlyCollection<ValidationError> Validate(string name)
        {
            if (string.IsNullOrWhiteSpace((name)))
            {
                return new List<ValidationError>() {new IsEmptyError()};
            }

            var errors = new List<ValidationError>();
            if (!Regex.IsMatch(name, @"^(\p{L}|\d|-| )+$", RegexOptions.CultureInvariant))
            {
                errors.Add(new IsInvalidCharacterError());
            }

            if (name.Length>20)
            {
                errors.Add(new IsInvalidLengthError());
            }

            return errors;
        }

        public class IsEmptyError : SimpleValidationError { }

        public class IsInvalidCharacterError : SimpleValidationError { }

        public class IsInvalidLengthError : SimpleValidationError { }
    }
}