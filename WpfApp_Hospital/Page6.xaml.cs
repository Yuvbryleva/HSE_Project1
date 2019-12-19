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
using APP_Hospital.Models;

namespace WpfApp_Hospital
{
    /// <summary>
    /// Interaction logic for Page6.xaml
    /// </summary>
    public partial class Page6 : Page
    {
        APP_Hospital.Hospital hosp;
        

        public Page6(ref APP_Hospital.Hospital hosp_)
        {
            InitializeComponent();
            hosp = hosp_;
            ListBoxDoctors.ItemsSource = hosp.doctors;
            
            
        }

        private void OKClick(object sender, RoutedEventArgs e)
        {
            string item = ListBoxDoctors.SelectedItem as string;
            DateTime dt;
            bool check;
            if (DateTime.TryParse(TbDateTime.Text, out dt) == false)
            {
                MessageBox.Show("Please, enter the format of (yyyy-mm-dd hh:mm:ss)");
                return;
            }
            else
            {
                if (DateTime.Parse(TbDateTime.Text) < DateTime.Now)
                {
                    MessageBox.Show("Please, check your date is in the future");
                    return;
                }
                else
                {
                    DateTime dateTime = DateTime.Parse(TbDateTime.Text);
                    check = hosp.AddAppointment(dateTime, hosp.CurrentUserLogin, item);

                }
            }
            if (check == false)
            {
                MessageBox.Show("Sorry, this doctor is occupied for this time");
                return;
            }
            else
            {
                MessageBox.Show("Appointment added. Check in section 2");
                hosp.SaveData();
                this.NavigationService.Navigate(new Page4(ref hosp));
            }

        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page4(ref hosp));
        }
    }
}
