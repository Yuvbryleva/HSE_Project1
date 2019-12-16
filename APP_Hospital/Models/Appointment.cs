using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_Hospital.Models
{
    public class Appointment
    {
        public int App_Id { get; set; }
        public DateTime App_Time { get; set; }
        public Patient App_Patient { get; set; }
        public string Doctor { get; set; }
    }
}
