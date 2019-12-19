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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page // Пример наследования классов
    {
        APP_Hospital.Hospital hosp;
        public Page1(ref APP_Hospital.Hospital hosp_)
        {
            InitializeComponent();
            hosp = hosp_;
        }
        

        private void AuthClick(object sender, RoutedEventArgs e)
        {
             this.NavigationService.Navigate(new Page3(ref hosp));
        }

        private void RegClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page2(ref hosp));
        }
    }
}
