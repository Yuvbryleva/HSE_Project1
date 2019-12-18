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
    /// Interaction logic for Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        APP_Hospital.Hospital hosp;
        public Page5(ref APP_Hospital.Hospital hosp_)
        {
            InitializeComponent();
            hosp = hosp_;
            List<GridData> gd = new List<GridData>();
            int CurrentUserId = -1;
            foreach (Patient item in hosp.patients)
            {
                if (item.Email == hosp.CurrentUserLogin)
                    CurrentUserId = item.Patient_Id;
            }

            foreach (Appointment item in hosp.appointments)
                if (item.Patient_Id == CurrentUserId)
                {
                    gd.Add(new GridData() { Time = item.App_Time, Doctor = item.Doctor });
                }
            AppDG.ItemsSource = gd;
        }

       public class GridData
        {
            public DateTime Time { get; set; }
            public string Doctor { get; set; }
            
        }

        private void OKClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page4(ref hosp));
        }
    }
}
