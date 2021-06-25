using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO_HospitalManagement;

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

        public static void AddPatient(string name, string dob, string address, string phone)
        {
            try
            {

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
