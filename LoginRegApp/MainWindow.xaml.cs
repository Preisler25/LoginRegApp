using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginRegApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            registerPage.Show();
            this.Close();
        }

        private void LogingUser_Click(object sender, RoutedEventArgs e)
        {
            string username = NameTextBox.Text;
            string password = PasswordBox.Password;

            //check if all fields are filled
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill all fields", "hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //check if user exists
            var users = User.FromFile("users.txt");
            var user = users.Find(u => u.Username == username && u.Password == password);
            if (user == null)
            {
                MessageBox.Show("User does not exist or wrong password", "hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Login successful", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}