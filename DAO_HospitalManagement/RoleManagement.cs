using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_HospitalManagement
{
    public class RoleManagement : DBConnect
    {
        private static RoleManagement _instance = null;
        public RoleManagement Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RoleManagement();
                }
                return _instance;
            }
        }

        static public void CreateRole(string roleName)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "CREATE ROLE " + roleName;
            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine("Successfully created role " + roleName);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }

        }

        static public void DeleteRole(string roleName)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "DROP ROLE " + roleName;
            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine("Successfully deleted role " + roleName);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
        }

        public static DataTable ShowRolePrivs(string rolename)
        {
            //Instantiate OracleDataAdapter to create DataSet
            OracleDataAdapter rolesAdapter = new OracleDataAdapter();

            //Fetch ROLES
            try
            {
                rolesAdapter.SelectCommand = new OracleCommand($"SELECT * FROM DBA_TAB_PRIVS where grantee='{rolename}'", _conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Instantiate DataSet object
            DataTable dt = new DataTable();

            //Fill the DataSet with data from database table
            rolesAdapter.Fill(dt);

            return dt;
        }

        public static DataTable GetAllTables()
        {
            //Instantiate OracleDataAdapter to create DataSet
            OracleDataAdapter rolesAdapter = new OracleDataAdapter();

            //Fetch ROLES
            try
            {
                rolesAdapter.SelectCommand = new OracleCommand($"select * from user_tables", _conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Instantiate DataSet object
            DataTable dt = new DataTable();

            //Fill the DataSet with data from database table
            rolesAdapter.Fill(dt);

            return dt;
        }

        static public DataTable GetAllRoles()
        {
            //Instantiate OracleDataAdapter to create DataSet
            OracleDataAdapter rolesAdapter = new OracleDataAdapter();

            //Fetch ROLES
            try
            {
                rolesAdapter.SelectCommand = new OracleCommand("SELECT * FROM DBA_ROLES WHERE ROLE_ID > 105 AND ROLE_ID < 200000", _conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Instantiate DataSet object
            DataTable dt = new DataTable();

            //Fill the DataSet with data from database table
            rolesAdapter.Fill(dt);

            return dt;
        }

        public static DataTable CheckRole(string rolename)
        {
            //Instantiate OracleDataAdapter to create DataSet
            OracleDataAdapter rolesAdapter = new OracleDataAdapter();

            //Fetch ROLES
            try
            {
                rolesAdapter.SelectCommand = new OracleCommand($"SELECT * FROM DBA_ROLES WHERE ROLE = '{rolename}'", _conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Instantiate DataSet object
            DataTable dt = new DataTable();

            //Fill the DataSet with data from database table
            rolesAdapter.Fill(dt);

            return dt;
        }

        public static DataTable GetRoleUsers(string rolename)
        {
            //Instantiate OracleDataAdapter to create DataSet
            OracleDataAdapter rolesAdapter = new OracleDataAdapter();

            //Fetch ROLE users
            try
            {
                rolesAdapter.SelectCommand = new OracleCommand($"select * from DBA_ROLE_PRIVS where granted_role='{rolename}'", _conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //Instantiate DataSet object
            DataTable dt = new DataTable();

            //Fill the DataSet with data from database table
            rolesAdapter.Fill(dt);

            return dt;
        }

        /// <summary>
        /// Function to grant object privileges to user
        /// </summary>
        /// <remarks>
        /// PRIVILEGES: INSERT, UPDATE, DELETE, INDEX, EXECUTE
        /// </remarks>
        /// <param name="privileges">input privileges separated by comma</param>
        /// <param name="adminOption">True: admin option is enabled, False: admin option is disabled </param>
        static public void GrantObjectPrivileges(string roleName, string tableName, string privileges)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"GRANT {privileges} ON {tableName} TO {roleName}";

            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine($"Successfully granted {privileges} on {tableName} to {roleName}");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Function to grant system privileges to user
        /// </summary>
        /// <remarks>
        /// PRIVILEGES: CREATE SESSION, CREATE TABLE, CREATE VIEW, CREATE PROCEDURE, SYSDBA, SYSOPER
        /// </remarks>
        /// <param name="privileges">input privileges separated by comma</param>        
        /// <param name="adminOption">True: admin option is enabled, False: admin option is disabled </param>

        static public void GrantSystemPrivileges(string roleName, string privileges, bool adminOption)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"GRANT {privileges} TO {roleName}";

            if (adminOption)
            {
                cmd.CommandText += " WITH ADMIN OPTION";
            }

            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine($"Successfully granted {privileges} to {roleName}");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <param name="privileges">Input privileges separated by comma</param>        
        static public void RevokeSystemPrivileges(string roleName, string privileges)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"REVOKE {privileges} FROM {roleName}";

            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine($"Successfully revoked {privileges} from {roleName}");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <param name="privileges">Input privileges separated by comma</param>        
        static public void RevokeObjectPrivileges(string roleName, string tableName, string privileges)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"REVOKE {privileges} ON {tableName} FROM {roleName}";

            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine($"Successfully revoked {privileges} on {tableName} from {roleName}");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
