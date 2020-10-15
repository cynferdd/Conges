using AccountManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManagement.Web
{
    public class AccountDto
    {

        public int AccountNumber { get; set; }

        public string Name { get; set; }

        public DateTime? ArchiveDate { get; set; }

        public DateTime? AcquisitionStart { get; set; }

        public DateTime? AcquisitionEnd { get; set; }

        public DateTime? ConsommationStart { get; set; }

        public DateTime? ConsommationEnd { get; set; }

        public decimal? AmountGainedPerFrequency { get; set; }

        public string? Frequency { get; set; }

        public static AccountDto FromDomain(Account account)
        {
            if (account is null)
            {
                return new AccountDto();
            }
            var accountDto =  new AccountDto
            {
                AccountNumber = account.Id,
                Name = account.Name,
                ArchiveDate = account.ArchiveDate
            };

            if (account is LeaveAccount leaveAccount)
            {
                accountDto.AcquisitionStart = leaveAccount.AcquisitionStart;
                accountDto.AcquisitionEnd = leaveAccount.AcquisitionEnd;
                accountDto.ConsommationStart = leaveAccount.ConsommationStart;
                accountDto.ConsommationEnd = leaveAccount.ConsommationEnd;
                accountDto.AmountGainedPerFrequency = leaveAccount.AmountGainedPerFrequency;
                accountDto.Frequency = leaveAccount.Frequency.ToString();
            }

            return accountDto;
        }

        
    }
}
