using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP_Hospital.Models;
using Newtonsoft.Json;

namespace APP_Hospital
{
    public class Hospital
    {
        public List<Patient> patients = new List<Patient>();
        public List<Appointment> appointments = new List<Appointment>();
        public List<string> doctors = new List<string>();

       public Hospital()
        {
            LoadData();
        }
        private const string PatientsFileName = "..\\..\\..\\APP_Hospital\\Data\\Patients.json";
        private T Deserialize<T>(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<T>(jsonReader);
                }
            }
        }
        private void LoadData()
        {
            patients = Deserialize<List<Patient>>(PatientsFileName);
        }

    }
}
