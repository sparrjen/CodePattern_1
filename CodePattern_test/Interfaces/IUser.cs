using System;
using System.Collections.Generic;
using System.Text;

namespace CodePattern_1.Interfaces
{
    public interface IUser
    {
        public int SSO { get; set; }
        public string UserName { get; set; }
        public int PhoneNo { get; set; }
        public string Email { get; set; }

    }
}
