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
                Frequency.Month)
                .Equals(
                    Validation.Invalid<LeaveAccount>(
                        new LeaveAccount.IsInvalidConsommationPeriodError())));
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
                    Frequency.Month)
                .Equals(
                    Validation.Valid<LeaveAccount>(new LeaveAccount(
                        new AccountId(0), 
                        new AccountName("leave"), 
                        new Period(new DateTime(2020, 01, 01),new DateTime(2020, 03, 03)),
                        new Period(new DateTime(2020, 01, 01),new DateTime(2020, 03, 03)),
                        1,
                        Frequency.Month))));
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
                    Frequency.Month)
                .Equals(
                    Validation.Valid<LeaveAccount>(new LeaveAccount(
                        new AccountId(0), 
                        new AccountName("leave"), 
                        new Period(new DateTime(2020, 01, 01),new DateTime(2020, 03, 03)),
                        new Period(new DateTime(2022, 01, 01),new DateTime(2022, 03, 03)),
                        1,
                        Frequency.Month))));
        }

        [Fact]
        public void ShouldReturnInvalid_WhenAmountGainedIsNegative()
        {
            Check.That(LeaveAccount.TryCreate(new AccountId(0), 
                new AccountName("leave"), 
                new Period(new DateTime(2020, 01, 01),new DateTime(2020, 03, 03)),
                new Period(new DateTime(2022, 05, 17),new DateTime(2022, 07, 03)),
                -1,
                Frequency.Month))
                .Equals(
                    Validation.Invalid<LeaveAccount>(
                        new LeaveAccount.IsNegativeOrZeroAmountError()));
        }
        
        [Fact]
        public void ShouldReturnInvalid_WhenAmountGainedIsZero()
        {
            Check.That(LeaveAccount.TryCreate(new AccountId(0), 
                    new AccountName("leave"), 
                    new Period(new DateTime(2020, 01, 01),new DateTime(2020, 03, 03)),
                    new Period(new DateTime(2022, 05, 17),new DateTime(2022, 07, 03)),
                    0,
                    Frequency.Month))
                .Equals(
                    Validation.Invalid<LeaveAccount>(
                        new LeaveAccount.IsNegativeOrZeroAmountError()));
        }
        
        [Fact]
        public void ShouldReturnValid_WhenAmountGainedIsStrictlyPositive()
        {
            Check.That(LeaveAccount.TryCreate(new AccountId(0), 
                    new AccountName("leave"), 
                    new Period(new DateTime(2020, 01, 01),new DateTime(2020, 03, 03)),
                    new Period(new DateTime(2022, 05, 17),new DateTime(2022, 07, 03)),
                    123,
                    Frequency.Month))
                .Equals(
                    Validation.Valid<LeaveAccount>(
                        new LeaveAccount(
                            new AccountId(0), 
                            new AccountName("leave"), 
                            new Period(new DateTime(2020, 01, 01),new DateTime(2020, 03, 03)),
                            new Period(new DateTime(2022, 05, 17),new DateTime(2022, 07, 03)),
                            123,
                            Frequency.Month
                            )));
        }
    }
}