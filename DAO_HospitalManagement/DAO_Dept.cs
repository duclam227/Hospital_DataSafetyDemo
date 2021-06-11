using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_HospitalManagement
{
    public class DAO_Dept : DBConnect
    {
        private static DAO_Dept _instance = null;

        public static DAO_Dept Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DAO_Dept();
                }

                return _instance;
            }
        }

        public static void GetAllDept()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "select * from DEPARTMENT";
            cmd.Connection = _conn;
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Debug.WriteLine(dr["DEPARTMENT_ID"].ToString());
                    Debug.WriteLine(dr["DEPARTMENT_NAME"].ToString());
                }
            }
            else
            {
                Debug.WriteLine("No Data In DataBase");
            }
        }
    }
}
