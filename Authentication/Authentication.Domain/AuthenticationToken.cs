using Shared.Core.DomainModeling;
using System;

namespace Authentication.Domain
{
    public class AuthenticationToken : SimpleValueObject<Guid>
    {
        public AuthenticationToken(Guid token) : base(token)
        {
        }
    }
}