using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_Hospital.Models
{
    class Appointment
    {
        public int Appointment_Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Patient App_Patient { get; set; }
        public Doctor App_Doctor { get; set; }
        public int MyProperty { get; set; }
    }
}
