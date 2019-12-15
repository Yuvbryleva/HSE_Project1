using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_Hospital.Models
{
    class Patient
    {
        public int Patient_Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CardNumber { get; set; }

    }
}
