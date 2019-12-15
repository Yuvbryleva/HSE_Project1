using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_Hospital.Models
{
    class Doctor
    {
        public int Doctor_Id { get; set; }
        public string Name { get; set; }
        public Department Department { get; set; }
        public decimal Price_per_hour { get; set; }
    }
}
