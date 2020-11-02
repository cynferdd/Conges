using System;
using AccountManagement.Domain;
using NFluent;
using Shared.Core.Validations;
using Xunit;

namespace AccountManagement.Unit.Test
{
    public class PeriodTest
    {
        [Fact]
        public void ShouldReturnInvalid_WhenEndDateBeforeStartDate()
        {
            Check.That(Period.TryCreate(new DateTime(2020, 10, 20),new DateTime(2018, 03, 05) ))
                .Equals(
                    Validation.Invalid<Period>(
                        new Period.IsInvalidPeriod()));
        }
        
        [Theory]
        [InlineData(2020, 01, 01, 2020, 05, 17)]
        [InlineData(2020, 01, 01, 2020, 01, 01)]
        public void ShouldReturnValid_WhenStartDateInferiorOrEqualToEndDate(int startYear, int startMonth, int startDay, int endYear, int endMonth, int endDay)
        {
            var startDate = new DateTime(startYear, startMonth, startDay);
            var endDate = new DateTime(endYear, endMonth, endDay);
            Check.That(Period.TryCreate(startDate, endDate))
                .Equals(
                    Validation.Valid(new Period(startDate, endDate)));
        }
    }
}