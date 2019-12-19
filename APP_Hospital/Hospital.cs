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
        public string CurrentUserLogin { get; set; }
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
        public bool AddPatient(string name, string login, string password)
        {
            int id_ = 0;
            foreach (Patient item in patients)
            {
                if (item.Patient_Id > id_)
                {
                    id_ = item.Patient_Id;
                }
                if (item.Email == login)
                    return false;
            }
            Patient p1 = new Patient()
            {
                Patient_Id = id_ + 1,
                Name = name,
                Email = login,
                Password = password
            };
            patients.Add(p1);
            return true;
        }
        public bool CheckPassword(string login, string password)
        {
            foreach (Patient item in patients)
            {
                if (item.Email == login)
                    if (item.Password == password)
                        return true;
            }
            return false;
        }
        public bool AddAppointment(DateTime app_Time, string  currentLogin, string doctor)
        {
            int patient_Id = -1;
            foreach (Patient p in patients)
            {
                if (p.Email == currentLogin)
                    patient_Id = p.Patient_Id;
            }
            int id_ = 0;
            foreach (Appointment item in appointments)
            {
                if (item.App_Id > id_)
                {
                    id_ = item.App_Id;
                }
                if (item.Doctor == doctor)
                {
                    if (item.App_Time == app_Time)
                        return false;
                }
            }
            Appointment app = new Appointment()
            {
                App_Id = id_ + 1,
                App_Time = app_Time,
                Patient_Id = patient_Id,
                Doctor = doctor
            };
            appointments.Add(app);
            return true;
        }

        public delegate string Message(string currentLogin);


        public string GetMessage(int MessageID)
        {
            Message msg;

            if (MessageID == 0)
            {
                msg = GetDate;
            }
            else
            {
                msg = GetNumber;
            }

            return msg(CurrentUserLogin);
        }

        public string GetDate(string currentLogin)
        {
            int patient_Id = -1;
            foreach (Patient p in patients)
            {
                if (p.Email == currentLogin)
                    patient_Id = p.Patient_Id;
            }
            DateTime test = new DateTime(2050,01,01,00,00,00);
            foreach (Appointment app in appointments)
            {
                if (app.Patient_Id == patient_Id)
                {
                    if (app.App_Time > DateTime.Now)
                    {
                        if (app.App_Time < test)
                            test = app.App_Time;
                    }
                }
            }
            return "Next Appointment will be at " + String.Format("yyyy-mm-dd hh:mm:ss", test);
        }
        public string GetNumber(string currentLogin)
        {
            int patient_Id = -1;
            foreach (Patient p in patients)
            {
                if (p.Email == currentLogin)
                    patient_Id = p.Patient_Id;
            }
            int counter = 0;
            foreach (Appointment app in appointments)
            {
                if (app.Patient_Id == patient_Id)
                {
                    counter += 1;
                }
            }
            return "Total appointments: " + string.Format ("0",counter);
        }
    }
}
