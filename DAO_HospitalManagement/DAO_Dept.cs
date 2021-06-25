using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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

        public static void AddPatient(int id, string name, string dob, string address, string phone)
        {
            string cmdText = $"insert into atbm.patient values ({id}, '{name}', '{dob}', '{address}', '{phone}')";

            try
            {
                OracleCommand cmd = new OracleCommand(cmdText, _conn);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public static DataTable GetAllPatient()
        {
            DataTable result = new DataTable();

            OracleDataAdapter adapter = new OracleDataAdapter();

            //Fetch roles
            try
            {
                adapter.SelectCommand = new OracleCommand($"select * from atbm.patient", _conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Fill the DataSet with data from database table
            adapter.Fill(result);

            return result;
        }

        public static DataTable GetAmount(string tablename)
        {
            DataTable result = new DataTable();

            OracleDataAdapter adapter = new OracleDataAdapter();

            //Fetch roles
            try
            {
                adapter.SelectCommand = new OracleCommand($"select count(*) from atbm.{tablename}", _conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Fill the DataSet with data from database table
            adapter.Fill(result);

            return result;
        }
    }
}
