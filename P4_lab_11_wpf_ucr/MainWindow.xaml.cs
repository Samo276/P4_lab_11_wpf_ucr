using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P4_lab_11_wpf_ucr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> users = new List<User>()
        {
            new User("Jan", "haslo1"),
            new User("Ben", "haslo2"),
            new User("Qun", "haslo3"),
        };
        public event EventHandler<LoginFailureEventArgs> LoginFailed;
        public event EventHandler<EventArgs> LoginSucces;
        public MainWindow()
        {
            
            InitializeComponent();
            new LoginControl();
            LoginFailed += CustomLoginControl.OnLoginFailure;
            LoginSucces += CustomLoginControl.OnLoginSucces;
        }
        public void CostomLoginControl_LoginAttempt(object sender, LoginEventArgs e)
        {
            var user = users.Where(x => x.CheckLogin(e.Login, e.Password)).SingleOrDefault();

            if (user == null)
            {
                LoginFailed?.Invoke(this, new LoginFailureEventArgs()
                {
                    Errors = new List<LoginFailureEventArgs.LoginError>()
                    {
                        new LoginFailureEventArgs.LoginError()
                        {
                            Field = LoginFields.All,
                            ErrorMessage = "wrong username or password"
                        }
                    }
                });
            }
            else
            {
                LoginSucces?.Invoke(this, EventArgs.Empty);
            }
        }
        
    }
}
