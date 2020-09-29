using System;

namespace Authentication.Domain
{
    public class User
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public bool EstCompteBloque => 
            NbTentativesConnexions > 2;

        public int NbTentativesConnexions { get; set; } = 0;
    }
}
