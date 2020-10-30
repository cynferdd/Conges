using System;

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

        public Period AcquisitionPeriod { get; set; }

        public Period ConsommationPeriod { get; set; }

        public decimal AmountGainedPerFrequency { get; set; }

        public Frequency Frequency { get; set; }
    }
}
