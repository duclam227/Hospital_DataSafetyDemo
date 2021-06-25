using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO_HospitalManagement;
using System.Data;

namespace BUS_HospitalManagement
{
    public class BUS_Dept
    {
        private static BUS_Dept _instance = null;

        public static BUS_Dept Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BUS_Dept();
                }

                return _instance;
            }
        }

        public static void GetAllDept()
        {
            DAO_HospitalManagement.DAO_Dept.GetAllDept();
        }

        public static int GetAmount(string tablename)
        {
            int result = 0;

            DataTable dt = DAO_Dept.GetAmount(tablename);
            result = int.Parse(dt.Rows[0][0].ToString());

            return result;
        }

        public static void AddPatient(string name, string dob, string address, string phone)
        {
            address = AesCrypto.EncryptData(address);
            phone = AesCrypto.EncryptData(phone);

            int id = GetAmount("PATIENT") + 1;

            try
            {
                DAO_HospitalManagement.DAO_Dept.AddPatient(id, name, dob, address, phone);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static List<Patient> GetAllPatient()
        {
            List<Patient> patients = new List<Patient>();

            DataTable dt = DAO_Dept.GetAllPatient();
            foreach(DataRow row in dt.Rows)
            {
                Patient tmp = new Patient();
                tmp.Id = int.Parse(row["PATIENT_ID"].ToString());
                tmp.Name = row["PATIENT_NAME"].ToString();
                tmp.Dob = row["PATIENT_DOB"].ToString();
                tmp.Address = AesCrypto.DecryptData(row["PATIENT_ADDRESS"].ToString());
                tmp.Phone = AesCrypto.DecryptData(row["PATIENT_PHONE"].ToString());

                patients.Add(tmp);
            }

            return patients;
        }
    }

    public class Patient
    {
        private int _id;
        private string _name;
        private string _dob;
        private string _address;
        private string _phone;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Dob { get => _dob; set => _dob = value; }
        public string Address { get => _address; set => _address = value; }
        public string Phone { get => _phone; set => _phone = value; }
    }
}
