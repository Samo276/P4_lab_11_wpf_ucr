using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public event EventHandler<LoginEventArgs> LoginAtempt;
        public string Login { get; set; }
        public SecureString Password { get; set; }
        public LoginControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ErrorStackPanel.Children.Clear();
            Login = LoginTextBox.Text;
            Password = PasswordBox1.SecurePassword;
            LoginAtempt?.Invoke(this, new LoginEventArgs(Login, Password));
        }
        public void OnLoginSucces(object sender, EventArgs e)
        {
            
        }
        public void OnLoginFailure(object sender, LoginFailureEventArgs e)
        {
            foreach(var item in e.Errors)
            {
                ErrorStackPanel.Children.Add(
                    new Label()
                    {
                        Content= $"[{item.Field}] {item.ErrorMessage}",
                        Foreground = new SolidColorBrush(Colors.Red)
                    });
            }
            Login = string.Empty;
            PasswordBox1.Clear();

        }
            
    }
}
