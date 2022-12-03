using Students_IS_Enriquez.Models;
using Students_IS_Enriquez.Includes;
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
using Students_IS_Enriquez.Views;

namespace Students_IS_Enriquez.Views
{
    /// <summary>
    /// Interaction logic for Login_Signup_Window.xaml
    /// </summary>
    public partial class Login_Signup_Window : Window
    {

        private SystemUsers system = new();
        private SQLconfig SQLConfig = new();
        private MainWindow main = new();
        public Login_Signup_Window()
        {
            InitializeComponent();
        }


        private void BtnSignup_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            cardLogin.Visibility = Visibility.Visible;
            CardSignup.Visibility = Visibility.Collapsed;
        }

        private void Btnsignin_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            cardLogin.Visibility = Visibility.Collapsed;
            CardSignup.Visibility = Visibility.Visible;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var a = await SQLconfig.Conopen();
            if (a)
            {
                MessageBox.Show("Connection open");
            }
            else
            {
                MessageBox.Show("Connection Error");
            }

        }


        private async void Btnreg_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var a = await system.AddSystemUser(txtfname.Text, txtlname.Text, txtUname.Text, txtPass.Password);
          
        }

        private void addstud_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var a = new StudentAdd();
            a.ShowDialog();
        }

        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
          var a =  await system.LoginUser(Usernametxt.Text, Passtxt.Password);
            if (!a) return;           
                Close();
                main.ShowDialog(); 
            
        }

        private void Usernametxt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

