using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LoginRegApp
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Window
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void RegUser_Click(object sender, RoutedEventArgs e)
        {
            string username = NameTextBox.Text;
            string password = PasswordBox.Password;
            string password2 = PasswordBox2.Password;
            string email = EmailTextBox.Text;
            string realName = RealNameTextBox.Text;
            bool isAccep = EulaCheckBox.IsChecked.Value;

            //check if all fields are filled
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(password2) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(realName))
            {
                MessageBox.Show("Please fill all fields", "hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //check if passwords match
            if (password != password2)
            {
                MessageBox.Show("Passwords do not match", "hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //check if eula is accepted
            if (!isAccep)
            {
                MessageBox.Show("Please accept EULA", "hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //check if user already exists
            List<User> users = User.FromFile("users.txt");
            foreach (var user in users)
            {
                if (user.Username == username)
                {
                    MessageBox.Show("User already exists", "hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            //check if password is strong
            if (!isPasswordStrong(password))
            {
                MessageBox.Show("Password is not strong enough", "hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //save user
            User newUser = new User(username, password, email, realName);
            newUser.SaveToFile("users.txt");

            MessageBox.Show("User registered", "info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private bool isPasswordStrong(string passwors)
        {
            return passwors.Length >= 8 && passwors.Any(char.IsDigit) && passwors.Any(char.IsUpper) && passwors.Any(char.IsLower) && passwors.Any(ch => !char.IsLetterOrDigit(ch));
        }
    }
}
