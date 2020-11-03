using System;
using System.Collections.Generic;
using Shared.Core;
using Shared.Core.Validations;

namespace AccountManagement.Domain
{
    public class LeaveAccount : Account
    {
        public LeaveAccount(
            AccountId id, 
            AccountName name, 
            Period acquisitionPeriod,
            Period consommationPeriod,
            decimal amountGained,
            Frequency frequency)
            :base (id, name)
        {
            AcquisitionPeriod = acquisitionPeriod;
            ConsommationPeriod = consommationPeriod;
            AmountGainedPerFrequency = amountGained;
            Frequency = frequency;
        }

        public static Validation<LeaveAccount> TryCreate(
            AccountId id, 
            AccountName name, 
            Period acquisitionPeriod,
            Period consommationPeriod,
            decimal amountGained,
            Frequency frequency)
        {
            return 
                Validate(acquisitionPeriod, consommationPeriod, amountGained)
                    .ToValidation(
                        () => new LeaveAccount(
                            id,
                            name,
                            acquisitionPeriod,
                            consommationPeriod,
                            amountGained,
                            frequency));
        }

        private static IReadOnlyCollection<ValidationError> Validate(
            Period acquisitionPeriod,
            Period consommationPeriod,
            decimal amountGained)
        {
            var errors = new List<ValidationError>();

            if (consommationPeriod.Start < acquisitionPeriod.Start)
            {
                errors.Add(new IsInvalidConsommationPeriodError());
            }

            if (amountGained <= 0)
            {
                errors.Add(new IsNegativeOrZeroAmountError());
            }
            

            return errors;
        }

        public Period AcquisitionPeriod { get; set; }

        public Period ConsommationPeriod { get; set; }

        public decimal AmountGainedPerFrequency { get; set; }

        public Frequency Frequency { get; set; }

        public class IsInvalidConsommationPeriodError : SimpleValidationError { }

        public class IsNegativeOrZeroAmountError : SimpleValidationError { }
    }
}
