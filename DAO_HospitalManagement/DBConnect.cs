using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_HospitalManagement
{
    public class DBConnect
    {
        // create connection
        static protected OracleConnection _conn = new OracleConnection();

        public DBConnect()
        {
        }
        public DBConnect(string username, string pass)
        {
            OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();

            ocsb.Password = pass;
            ocsb.UserID = username;
            ocsb.DataSource = "localhost:1521/xepdb1";

            // connect
            try {
                _conn.ConnectionString = ocsb.ConnectionString;
                _conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Debug.WriteLine("Connection established (" + _conn.ServerVersion + ")");
        }
    }
}
