using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP_Hospital.Models;
using APP_Hospital;

namespace Hospital_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var hosp = new APP_Hospital.Hospital();
            foreach (Patient item in hosp.patients)
            {
                Console.WriteLine(item.Name);
            }
            foreach (Appointment item in hosp.appointments)
            {
                Console.WriteLine(item.Patient_Id);
            }
            
        }
    }
}
