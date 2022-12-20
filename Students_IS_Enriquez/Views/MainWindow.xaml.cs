using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
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
using System.Xml;
using Students_IS_Enriquez.Models;
using static Students_IS_Enriquez.Includes.SQLconfig;

namespace Students_IS_Enriquez.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Students> studentsList = new();
        public MainWindow()
        {
            InitializeComponent();
        }
        private async Task FillStudents()
        {
            try
            {
                txtsearchstudent.Text = "";
                studprogress.Visibility = Visibility.Visible;
                await Conopen();
                studentsList.Clear();
                Sqlcmd.Parameters.Clear();
                ListStudents.ItemsSource = null;
                Strsql = $"Select  * from TBLStudents";
                Sqlcmd.CommandText = Strsql;
                Sqlcmd.Connection = Cnn;
                Sqladapter.SelectCommand = Sqlcmd;
                Sqlreader = await Sqlcmd.ExecuteReaderAsync();
                while (Sqlreader.Read())
                {
                    //    var dte = Sqlreader["last_date_attended"];
                    //    var startDateTime = DateTime.ParseExact((dte as string)!, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    //    var a = startDateTime.Date.ToString("ddd, dd MMMM yyyy");
                    studentsList.Add(new Students
                    {
                        S_ID = Sqlreader["S_ID"].ToString()!,
                        S_Fname = Sqlreader["S_Fname"].ToString()!,
                        S_Lname = Sqlreader["S_Lname"].ToString()!,
                        S_Address = Sqlreader["S_Address"].ToString()!,
                        S_Mobile_Num = Sqlreader["S_Mobile_Num"].ToString()!,
                        S_B_Date = Sqlreader["S_B_Date"].ToString()!,

                    });
                }
                Sqlcmd.Dispose();
                await Sqlreader.CloseAsync();
                Strsql = "";
                ListStudents.ItemsSource = studentsList;
                studprogress.Visibility = Visibility.Collapsed;
                Sqlcmd.Dispose();
                await Sqlreader.CloseAsync();
                Cnn.Close();
                //Count total
                //await Tot_Count();

            }
            catch
            {
                studprogress.Visibility = Visibility.Collapsed;
            }
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

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await FillStudents();
        }

        private async void btnaddstudent_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            var a = new StudentAdd();
            a.ShowDialog();
            await FillStudents();
        }
    }
}
