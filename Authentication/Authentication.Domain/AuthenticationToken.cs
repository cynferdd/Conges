using Shared.Core.DomainModeling;
using System;
using System.Data;

namespace Authentication.Domain
{
    public class AuthenticationToken : SimpleValueObject<Guid>
    {
        public AuthenticationToken(Guid token) : base(token)
        {
        }
    }
}