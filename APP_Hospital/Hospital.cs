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
        private const string AppFileName = "..\\..\\..\\APP_Hospital\\Data\\Appointments.json";
        private const string DoctorsFileName = "..\\..\\..\\APP_Hospital\\Data\\Doctors.json";
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
        private void Serialize<T>(string fileName, T data)
        {
            using (var sw = new StreamWriter(fileName))
            {
                using (var jsonWriter = new JsonTextWriter(sw))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(jsonWriter, data);
                }
            }
        }
        private void LoadData()
        {
            patients = Deserialize<List<Patient>>(PatientsFileName);
            appointments = Deserialize<List<Appointment>>(AppFileName);
            doctors = Deserialize<List<string>>(DoctorsFileName);
        }

        public void SaveData()
        {
            Serialize(PatientsFileName, patients);
            Serialize(AppFileName, appointments);
            Serialize(DoctorsFileName, doctors);
        }
    }
}
