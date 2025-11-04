using Devyatochka.Database;
using Devyatochka.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Devyatochka.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        private UserService userService;
        public AuthPage()
        {
            InitializeComponent();

            userService = UserService.GetInstance();

            ClearFields();
        }

        private void buttonSignIn_Click(object sender, RoutedEventArgs e)
        {
            User user = userService.GetUserByLoginAndPass(textBoxLogin.Text, passwordBoxPassword.Password);

            if (user != null) { 
                ClearFields();

                this.NavigationService.Navigate(new Pages.AdminGeneralMenuPage());
            }
            else MessageBox.Show("Такого пользователя не существует или неверные логин или пароль");
        }

        private void buttonSignUp_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.SignUpPage());
        }

        private void ClearFields()
        {
            textBoxLogin.Clear();
            passwordBoxPassword.Clear();
        }
    }
}
