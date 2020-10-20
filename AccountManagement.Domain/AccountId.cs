using Shared.Core.DomainModeling;

namespace AccountManagement.Domain
{
    public class AccountId : Id<int>
    {
        public AccountId(int internalValue) : base(internalValue)
        {
        }
    }
}