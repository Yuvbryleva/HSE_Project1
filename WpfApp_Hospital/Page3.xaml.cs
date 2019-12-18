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
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        APP_Hospital.Hospital hosp;
        public Page3(ref APP_Hospital.Hospital hosp_)
        {
            InitializeComponent();
            hosp = hosp_;
        }

        private void OKClick(object sender, RoutedEventArgs e)
        {
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
            bool cp = hosp.CheckPassword(TbLogin.Text, TbPassword.Text);
            if (cp == false)
                MessageBox.Show("Login and/or password is not correct");
            else
                hosp.CurrentUserLogin = TbLogin.Text; 
                this.NavigationService.Navigate(new Page4(ref hosp));
        }

        private void BacktoMenuClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page1(ref hosp));
        }
    }
}
