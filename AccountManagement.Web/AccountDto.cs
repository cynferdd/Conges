using AccountManagement.Domain;
using System;
using System.Collections.Generic;
using Shared.Core;
using Shared.Core.Exceptions;
using Shared.Core.Validations;

namespace AccountManagement.Web
{
    public class AccountDto
    {

        public int AccountNumber { get; set; }

        public string Name { get; set; }

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
            var accountId = new AccountId(this.AccountNumber);
            var validatedName = AccountName.TryCreate(this.Name);
            
            if (IsNoLeaveAccount())
            {
                if (validatedName.IsInvalid)
                {
                    throw new ValidationException(validatedName.Errors);
                }
                
                return new NoLeaveAccount (accountId, validatedName.Value);
                
            }

            var validatedAcquisitionPeriod = Period.TryCreate(this.AcquisitionStart.Value, this.AcquisitionEnd.Value);
            
            
            var validatedConsommationPeriod = Period.TryCreate(this.ConsommationStart.Value, this.ConsommationEnd.Value);
            

            Validation.EnsureIsValid(validatedName, validatedAcquisitionPeriod, validatedConsommationPeriod);
            
            var validatedLeaveAccount = LeaveAccount.TryCreate(
                accountId,
                validatedName.Value,
                validatedAcquisitionPeriod.Value,
                validatedConsommationPeriod.Value,
                this.AmountGainedPerFrequency.Value,
                (Frequency) Enum.Parse(typeof(Frequency), this.Frequency));

            
            return validatedLeaveAccount.Value;
        }


        private bool IsNoLeaveAccount()
        {
            return string.IsNullOrEmpty(this.Frequency) ||
                   this.AcquisitionStart == null ||
                   this.AcquisitionEnd == null ||
                   this.AmountGainedPerFrequency == null ||
                   this.ConsommationStart == null ||
                   this.ConsommationEnd == null;
        }
    }
}
