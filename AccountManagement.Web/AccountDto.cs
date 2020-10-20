using AccountManagement.Domain;
using System;

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

        internal Account ToDomain()
        {
            if (
                    string.IsNullOrEmpty(this.Frequency) ||
                    this.AcquisitionStart == null ||
                    this.AcquisitionEnd == null ||
                    this.AmountGainedPerFrequency == null ||
                    this.ConsommationStart == null ||
                    this.ConsommationEnd == null
                )
            {
                return new NoLeaveAccount (this.AccountNumber, this.Name);
            }

            return new LeaveAccount(this.AccountNumber, this.Name)
            {
                AcquisitionStart = this.AcquisitionStart.Value,
                AcquisitionEnd = this.AcquisitionEnd.Value,
                ConsommationStart = this.ConsommationStart.Value,
                ConsommationEnd = this.ConsommationEnd.Value,
                AmountGainedPerFrequency = this.AmountGainedPerFrequency.Value,
                Frequency = (Frequency)Enum.Parse(typeof(Frequency), this.Frequency)
            };
        }
    }
}
