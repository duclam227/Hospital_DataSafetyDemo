using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO_HospitalManagement;

namespace BUS_HospitalManagement
{
    public class BUS_Employee
    {
        private static BUS_Employee _instance = null;

        public static BUS_Employee Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BUS_Employee();
                }

                return _instance;
            }
        }

        public DataTable GetEmployeeInformation()
        {
            try
            {
                return DAO_HospitalManagement.DAO_Employee.Instance.GetEmployeeInformation();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetExpense()
        {
            try
            {
                return DAO_HospitalManagement.DAO_Employee.Instance.GetExpense();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}