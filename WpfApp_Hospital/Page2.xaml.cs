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
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        APP_Hospital.Hospital hosp;
        public Page2(ref APP_Hospital.Hospital hosp_)
        {
            InitializeComponent();
            hosp = hosp_;
        }
        
        private void OKClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TbName.Text))
                {
                MessageBox.Show("No Name entered!");
                return;
            }
            if (String.IsNullOrEmpty(TbLogin.Text))
            {
                MessageBox.Show("No Login entered!");
                return;
            }
            if (String.IsNullOrEmpty(TbPassword.Text))
            {
                MessageBox.Show("No Password entered!");
                return;
            }
            bool ap = hosp.AddPatient(TbName.Text, TbLogin.Text, TbPassword.Text);
            if (ap == false)
                MessageBox.Show("Patient with this email is already registrated!");
            else
            {
                MessageBox.Show("User registrated successfully." + System.Environment.NewLine + "Please, authirize to proceed");
                hosp.SaveData();
                this.NavigationService.Navigate(new Page3(ref hosp));
            }
        }


        


        private void BacktoManuClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page1(ref hosp));
        }
    }
}
