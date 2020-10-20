using System;
using System.Collections.Generic;
using System.Text;

namespace AccountManagement.Domain
{
    public class NoLeaveAccount : Account
    {
        public NoLeaveAccount(int id, string name)
            : base(id, name)
        {

        }
    }
}
