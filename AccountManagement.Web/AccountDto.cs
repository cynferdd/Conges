using AccountManagement.Domain;
using System;
using Shared.Core.Exceptions;

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
                Name = (string)account.Name,
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
                var validatedName = AccountName.TryCreate(this.Name);
                // todo : faire tous les try create. 
                // Si tout est valide ok
                // sinon on concatène toutes les erreurs pour renvoyer le bon validationException
                // Validation.CombineErrors
                
                // todo : validation sur les périodes
                // la période de consommation commence après ou en même temps que la date de début de la période d'acquisition
                if (validatedName.IsInvalid)
                {
                    throw new ValidationException(validatedName.Errors);
                }
                
                return new NoLeaveAccount (new AccountId(this.AccountNumber), validatedName.Value);
                
                
            }

            return new LeaveAccount(
                new AccountId(this.AccountNumber), 
                new AccountName(this.Name),
                new Period(AcquisitionStart.Value, AcquisitionEnd.Value),
                new Period(ConsommationStart.Value, ConsommationEnd.Value),
                AmountGainedPerFrequency.Value,
                (Frequency)Enum.Parse(typeof(Frequency), this.Frequency)
                );
        }
    }
}
