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
                AccountNumber = (int)account.Id,
                Name = account.Name,
                ArchiveDate = account.ArchiveDate
            };

            if (account is LeaveAccount leaveAccount)
            {
                accountDto.AcquisitionStart = leaveAccount.AcquisitionPeriod.Start;
                accountDto.AcquisitionEnd = leaveAccount.AcquisitionPeriod.End;
                accountDto.ConsommationStart = leaveAccount.ConsommationPeriod.Start;
                accountDto.ConsommationEnd = leaveAccount.ConsommationPeriod.End;
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
                return new NoLeaveAccount (new AccountId(this.AccountNumber), this.Name);
            }

            return new LeaveAccount(
                new AccountId(this.AccountNumber), 
                this.Name,
                new Period(AcquisitionStart.Value, AcquisitionEnd.Value),
                new Period(ConsommationStart.Value, ConsommationEnd.Value),
                AmountGainedPerFrequency.Value,
                (Frequency)Enum.Parse(typeof(Frequency), this.Frequency)
                );
        }
    }
}
