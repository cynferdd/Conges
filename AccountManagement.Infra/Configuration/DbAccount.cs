using System;
using AccountManagement.Domain;

namespace AccountManagement.Infra.Configuration
{
    public class DbAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? ArchiveDate { get; set; }
        public DateTime? AcquisitionStartDate { get; set; }
        public DateTime? AcquisitionEndDate { get; set; }
        public DateTime? ConsommationStartDate { get; set; }
        public DateTime? ConsommationEndDate { get; set; }
        public decimal? AmountGained { get; set; }
        public Frequency? Frequency { get; set; }

        public Account ToDomain()
        {
            if (AcquisitionStartDate is null ||
                AcquisitionEndDate is null ||
                ConsommationStartDate is null ||
                ConsommationEndDate is null ||
                AmountGained is null ||
                Frequency is null)
            {
                return  new NoLeaveAccount(new AccountId(Id), new AccountName(Name));
            }

            return new LeaveAccount(
                new AccountId(Id),
                new AccountName(Name),
                new Period(AcquisitionStartDate.Value, AcquisitionEndDate.Value),
                new Period(ConsommationStartDate.Value, ConsommationEndDate.Value),
                AmountGained.Value,
                Frequency.Value
            );
        }

        public void UpdateFromDomain(Account account)
        {
            this.Name = (string) account.Name;
            this.ArchiveDate = account.ArchiveDate;
            if (account is LeaveAccount leaveAccount)
            {
                this.ConsommationStartDate = leaveAccount.ConsommationPeriod.Start;
                this.ConsommationEndDate = leaveAccount.ConsommationPeriod.End;
                this.AcquisitionStartDate = leaveAccount.AcquisitionPeriod.Start;
                this.AcquisitionEndDate = leaveAccount.AcquisitionPeriod.End;
                this.AmountGained = leaveAccount.AmountGainedPerFrequency;
                this.Frequency = leaveAccount.Frequency;
            };
        }
    }
}