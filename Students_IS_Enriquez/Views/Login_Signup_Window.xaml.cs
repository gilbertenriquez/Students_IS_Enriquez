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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Students_IS_Enriquez.Views
{
    /// <summary>
    /// Interaction logic for Login_Signup_Window.xaml
    /// </summary>
    public partial class Login_Signup_Window : Window
    {
        public Login_Signup_Window()
        {
            InitializeComponent();
        }

        private void signUp_Click_1(object sender, RoutedEventArgs e)
        {
           logIn.Visibility = Visibility.Collapsed;
            SignUp.Visibility = Visibility.Visible;
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            logIn.Visibility = Visibility.Visible;
            SignUp.Visibility = Visibility.Collapsed;
        }
    }
}
