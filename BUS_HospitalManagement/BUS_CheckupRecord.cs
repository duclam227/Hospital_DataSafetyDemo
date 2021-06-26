using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_HospitalManagement
{
    public class BUS_CheckupRecord
    {
        private static BUS_CheckupRecord _instance = null;

        public static BUS_CheckupRecord Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BUS_CheckupRecord();
                }

                return _instance;
            }
        }

        public DataTable GetAllRecords()
        {
            try
            {
                return DAO_HospitalManagement.DAO_CheckupRecord.Instance.GetAllRecords();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}