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

namespace WpfApp_Hospital
{
    /// <summary>
    /// Interaction logic for Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        APP_Hospital.Hospital hosp;
        public Page4(ref APP_Hospital.Hospital hosp_)
        {
            InitializeComponent();
            hosp = hosp_;
        }
        
        

        private void New_App_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void All_App_Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page5(ref hosp));
        }

        private void Date_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Number_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BacktoMenuClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page1(ref hosp));
        }
    }
}
