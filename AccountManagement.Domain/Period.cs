using System;
using System.Collections.Generic;
using Shared.Core.DomainModeling;

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
    }
}