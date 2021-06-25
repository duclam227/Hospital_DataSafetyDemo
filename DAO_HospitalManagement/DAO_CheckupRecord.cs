using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_HospitalManagement
{
    public class DAO_CheckupRecord : DBConnect
    {
        private static DAO_CheckupRecord _instance = null;

        public static DAO_CheckupRecord Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DAO_CheckupRecord();
                }

                return _instance;
            }
        }

        public DataTable GetAllRecords()
        {
            //Instantiate OracleDataAdapter to create DataSet
            OracleDataAdapter adapter = new OracleDataAdapter();

            //Fetch record
            try
            {
                adapter.SelectCommand = new OracleCommand($"SELECT * FROM atbm.checkuprecord", _conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Instantiate DataSet object
            DataTable dt = new DataTable();

            //Fill the DataSet with data from database table
            adapter.Fill(dt);

            return dt;
        }
    }
}
