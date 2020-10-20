using System;

namespace AccountManagement.Domain
{
    public class LeaveAccount : Account
    {
        public LeaveAccount(int id, string name)
            :base (id, name)
        {

        }

        public DateTime AcquisitionStart { get; set; }

        public DateTime AcquisitionEnd { get; set; }

        public DateTime ConsommationStart { get; set; }

        public DateTime ConsommationEnd { get; set; }

        public decimal AmountGainedPerFrequency { get; set; }

        public Frequency Frequency { get; set; }
    }
}
