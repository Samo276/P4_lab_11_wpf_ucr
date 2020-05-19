using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace P4_lab_11_wpf_ucr
{
    public class LoginEventArgs:EventArgs
    {
        public string Login { get; set; }
        public SecureString Password { get; set; }

        public LoginEventArgs(string login, SecureString password)
        {
            Login = login;
            Password = password;
        }
    }
}
