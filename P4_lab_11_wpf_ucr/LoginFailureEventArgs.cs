using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_lab_11_wpf_ucr
{
    public class LoginFailureEventArgs: EventArgs
    {
        //public string Login { get; set; }
        //tu jeszzce jedno ;pole
        public List<LoginError> Errors {get;set;}

    public class LoginError{
            public LoginFields Field {get;set;} 
            public string ErrorMessage { get; set; }
        }

    }
    public enum LoginFields
    {
        Login, 
        Password,
        All
    }
}
