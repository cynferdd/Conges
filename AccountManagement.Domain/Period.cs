using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Shared.Core;
using Shared.Core.DomainModeling;
using Shared.Core.Validations;

namespace AccountManagement.Domain
{
    public class Period : ValueObject
    {
        public Period(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
        public DateTime Start { get;}

        public DateTime End { get; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Start;
            yield return End;
        }
        
        public static Validation<Period> TryCreate(DateTime start, DateTime end) => 
            Validate(start, end).ToValidation(() => new Period(start, end));

        private static IReadOnlyCollection<ValidationError> Validate(DateTime start, DateTime end) =>
            end < start 
                ? new List<ValidationError> {new IsInvalidPeriod()} 
                : new List<ValidationError>();
        

        public class IsInvalidPeriod : SimpleValidationError { }
    }
}