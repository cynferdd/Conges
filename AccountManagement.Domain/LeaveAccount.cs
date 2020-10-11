using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManagement.Domain
{
    public class LeaveAccount : Account
    {
        public DateTime AcquisitionStart { get; set; }

        public DateTime AcquisitionEnd { get; set; }

        public DateTime ConsommationStart { get; set; }

        public DateTime ConsommationEnd { get; set; }

        public decimal AmountGainedPerFrequency { get; set; }

        public Frequency Frequency { get; set; }
    }
}
