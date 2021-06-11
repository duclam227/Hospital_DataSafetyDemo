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
    public class UserManagement : DBConnect
    {
        private static UserManagement _instance = null;
        public UserManagement Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserManagement();
                }
                return _instance;
            }
        }

        static public void CreateUser(string username, string password)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"CREATE USER {username} IDENTIFIED BY {password}";
            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine("Successfully created user " + username);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetUserTablePriv(string username, string tablename)
        {
            //Instantiate OracleDataAdapter to create DataSet
            OracleDataAdapter userAdapter = new OracleDataAdapter();

            //Fetch columns
            try
            {
                userAdapter.SelectCommand = new OracleCommand($"select column_name, select_priv, update_priv from columnprivs where table_name = '{tablename}' and username = '{username}'", _conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //Instantiate DataSet object
            DataTable dt = new DataTable();

            userAdapter.Fill(dt);

            return dt;
        }

        public static DataTable GetTableColumns(string tablename)
        {
            //Instantiate OracleDataAdapter to create DataSet
            OracleDataAdapter userAdapter = new OracleDataAdapter();

            //Fetch columns
            try
            {
                userAdapter.SelectCommand = new OracleCommand($"SELECT column_name from user_tab_columns where table_name='{tablename}'", _conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //Instantiate DataSet object
            DataTable dt = new DataTable();

            userAdapter.Fill(dt);

            return dt;
        }

        static public void DeleteUser(string username)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"DROP USER {username}";
            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine("Successfully deleted user " + username);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ShowUserPrivs(string username)
        {
            //Instantiate OracleDataAdapter to create DataSet
            OracleDataAdapter rolesAdapter = new OracleDataAdapter();

            //Fetch ROLES
            try
            {
                rolesAdapter.SelectCommand = new OracleCommand($"SELECT * FROM DBA_TAB_PRIVS where grantee='{username}'", _conn);
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

        public static void GrantSelectOnCol(string username, string tablename, string columns)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"create or replace view {username}_{tablename}_view as select {columns} from {tablename}";
            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine("Successfully created view");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            OracleCommand cmd2 = new OracleCommand();
            cmd2.CommandText = $"grant select on {username}_{tablename}_view to {username}";
            cmd2.Connection = _conn;
            try
            {
                int res = cmd2.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine("Successfully granted select");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteRows(string username, string tablename)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"delete from COLUMNPRIVS where TABLE_NAME = '{tablename}' and USERNAME = '{username}'";
            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine("Successfully deleted rows");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateColumnPrivs(string username, string tablename, string columnname, int selectBit, int updateBit)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"insert into COLUMNPRIVS(TABLE_NAME, COLUMN_NAME, USERNAME, SELECT_PRIV, UPDATE_PRIV) VALUES ('{tablename}', '{columnname}', '{username}', {selectBit}, {updateBit})";
            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine("Successfully granted column priv");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void GrantUpdateOnCol(string username, string tablename, string columnname)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"grant update({columnname}) on {tablename} to {username}";
            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine("Successfully granted column update ");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public DataTable GetAllUsers()
        {
            //Instantiate OracleDataAdapter to create DataSet
            OracleDataAdapter userAdapter = new OracleDataAdapter();

            //Fetch Details
            try
            {
                userAdapter.SelectCommand = new OracleCommand("select * from all_users where created > TO_DATE(20210401, 'YYYY/MM/DD')", _conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //Instantiate DataSet object
            DataTable dt = new DataTable();

            userAdapter.Fill(dt);

            return dt;
        }

        static public void ChangeUserPassword(string username, string newPassword)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"ALTER USER {username} IDENTIFIED BY {newPassword}";
            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine("Successfully alter user " + username);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable CheckUser(string username)
        {
            //Instantiate OracleDataAdapter to create DataSet
            OracleDataAdapter rolesAdapter = new OracleDataAdapter();

            //Fetch ROLES
            try
            {
                rolesAdapter.SelectCommand = new OracleCommand($"SELECT * FROM ALL_USERS WHERE USERNAME = '{username}'", _conn);
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

        public static void RevokeRoleFromUser(string rolename, string username)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"REVOKE {rolename} FROM {username}";
            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine("Successfully revoked role " + rolename + "from user " + username);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void GrantRoleToUser(string rolename, string username)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"GRANT {rolename} TO {username}";
            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine("Successfully granted user " + username + " role " + rolename);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Function to lock or unlock user account
        /// </summary>
        /// <param name="command">input "LOCK" to lock user, "UNLOCK" to unlock user</param>
        static public void LockOrUnlockUser(string username, string command)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"ALTER USER {username} ACCOUNT {command}";
            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine("Successfully alter user " + username);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public void SetUserDefaultRole(string username, string roleName)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"ALTER USER {username} DEFAULT ROLE {roleName}";
            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine("Successfully alter user " + username);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Function to grant object privileges to user
        /// </summary>
        /// <remarks>
        /// PRIVILEGES: INSERT, UPDATE, DELETE, INDEX, EXECUTE
        /// </remarks>
        /// <param name="privileges">Input privileges separated by comma</param>
        /// <param name="adminOption">True: admin option is enabled, False: admin option is disabled </param>
        static public void GrantObjectPrivileges(string username, string tableName, string privileges, bool adminOption)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"GRANT {privileges} ON {tableName} TO {username}";

            if (adminOption)
            {
                cmd.CommandText += " WITH GRANT OPTION";
            }

            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine($"Successfully granted {privileges} on {tableName} to {username}");
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
        /// <param name="privileges">Input privileges separated by comma</param>        
        /// <param name="adminOption">True: admin option is enabled, False: admin option is disabled </param>

        static public void GrantSystemPrivileges(string username, string privileges, bool adminOption)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"GRANT {privileges} TO {username}";

            if (adminOption)
            {
                cmd.CommandText += " WITH GRANT OPTION";
            }

            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine($"Successfully granted {privileges} to {username}");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <param name="privileges">Input privileges separated by comma</param>        
        static public void RevokeSystemPrivileges(string username, string privileges)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"REVOKE {privileges} FROM {username}";

            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine($"Successfully revoked {privileges} to {username}");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <param name="privileges">Input privileges separated by comma</param>        
        static public void RevokeObjectPrivileges(string username, string tableName, string privileges)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"REVOKE {privileges} ON {tableName} FROM {username}";

            cmd.Connection = _conn;
            try
            {
                int res = cmd.ExecuteNonQuery();
                if (res == -1)
                {
                    Debug.WriteLine($"Successfully revoke {privileges} on {tableName} from {username}");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
