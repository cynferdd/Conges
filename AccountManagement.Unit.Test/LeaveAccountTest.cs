using System;
using AccountManagement.Domain;
using NFluent;
using Shared.Core.Validations;
using Xunit;

namespace AccountManagement.Unit.Test
{
    public class LeaveAccountTest
    {
        [Fact]
        public void ShouldReturnInvalid_WhenConsommationPeriodStartsBeforeAcquisitionStartDate()
        {
            Check.That(LeaveAccount.TryCreate(
                new AccountId(0), 
                new AccountName("leave"), 
                new Period(new DateTime(2020, 01, 01),new DateTime(2020, 03, 03)),
                new Period(new DateTime(2019, 01, 01),new DateTime(2020, 03, 03)),
                1,
                Frequency.Day)
                .Equals(
                    Validation.Invalid<LeaveAccount>(
                        new LeaveAccount.IsInvalidConsommationPeriod())));
        }
        
        [Fact]
        public void ShouldReturnValid_WhenConsommationPeriodStartsAtTheSameTimeThanAcquisitionStartDate()
        {
            Check.That(LeaveAccount.TryCreate(
                    new AccountId(0), 
                    new AccountName("leave"), 
                    new Period(new DateTime(2020, 01, 01),new DateTime(2020, 03, 03)),
                    new Period(new DateTime(2020, 01, 01),new DateTime(2020, 03, 03)),
                    1,
                    Frequency.Day)
                .Equals(
                    Validation.Valid<LeaveAccount>(new LeaveAccount(
                        new AccountId(0), 
                        new AccountName("leave"), 
                        new Period(new DateTime(2020, 01, 01),new DateTime(2020, 03, 03)),
                        new Period(new DateTime(2020, 01, 01),new DateTime(2020, 03, 03)),
                        1,
                        Frequency.Day))));
        }
        
        [Fact]
        public void ShouldReturnValid_WhenConsommationPeriodStartsAfterAcquisitionStartDate()
        {
            Check.That(LeaveAccount.TryCreate(
                    new AccountId(0), 
                    new AccountName("leave"), 
                    new Period(new DateTime(2020, 01, 01),new DateTime(2020, 03, 03)),
                    new Period(new DateTime(2022, 01, 01),new DateTime(2020, 03, 03)),
                    1,
                    Frequency.Day)
                .Equals(
                    Validation.Valid<LeaveAccount>(new LeaveAccount(
                        new AccountId(0), 
                        new AccountName("leave"), 
                        new Period(new DateTime(2020, 01, 01),new DateTime(2020, 03, 03)),
                        new Period(new DateTime(2022, 01, 01),new DateTime(2020, 03, 03)),
                        1,
                        Frequency.Day))));
        }
    }
}