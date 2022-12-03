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

namespace Students_IS_Enriquez.Views
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

        private void BTNclose_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BTNclose.Visibility = Visibility.Collapsed;
            BTNexpand.Visibility = Visibility.Visible;    

        }

        private void BTNexpand_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BTNclose.Visibility = Visibility.Visible;
            BTNexpand.Visibility = Visibility.Collapsed;
        }
    }
}
