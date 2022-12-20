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
using Students_IS_Enriquez.Models;
using Students_IS_Enriquez.Includes;

namespace Students_IS_Enriquez.Views
{
    /// <summary>
    /// Interaction logic for StudentAdd.xaml
    /// </summary>
    public partial class StudentAdd : Window
    {
        private AddStudent addstudent = new();
        public StudentAdd()
        {
            InitializeComponent();
        }

        private async void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            await addstudent.Addstudent(txtID.Text,txtfname.Text,txtlname.Text,txtAdd.Text,txtnumb.Text,txtdate.Text);
           Close();

        }
    }
}
