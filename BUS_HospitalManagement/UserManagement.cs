using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_HospitalManagement
{
    public class UserManagement
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
            DAO_HospitalManagement.UserManagement.CreateUser(username, password);
        }

        public static DataTable GetTableColumns(string tablename)
        {
            return DAO_HospitalManagement.UserManagement.GetTableColumns(tablename);
        }

        public static void GetUserTablePriv(DataTable test, string username, string tablename)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DAO_HospitalManagement.UserManagement.GetUserTablePriv(username, tablename);
                test.Columns.Add("SELECT_PRIV", typeof(bool));
                test.Columns.Add("UPDATE_PRIV", typeof(bool));

                if(dt.Rows.Count == 0)
                {
                    for (int i = 0; i < test.Rows.Count; i++)
                    {
                        test.Rows[i]["SELECT_PRIV"] = false;
                        test.Rows[i]["UPDATE_PRIV"] = false;
                    }
                    return;
                }

                for (int i=0; i < test.Rows.Count; i++)
                {
                    for(int j = 0; j < dt.Rows.Count; j++)
                    {
                        if(test.Rows[i]["COLUMN_NAME"].ToString() == dt.Rows[j]["COLUMN_NAME"].ToString())
                        {
                            if(dt.Rows[j]["SELECT_PRIV"].ToString() == "1")
                            {
                                test.Rows[i]["SELECT_PRIV"] = true;
                            }
                            else
                            {
                                test.Rows[i]["SELECT_PRIV"] = false;
                            }

                            if (dt.Rows[j]["UPDATE_PRIV"].ToString() == "1")
                            {
                                test.Rows[i]["UPDATE_PRIV"] = true;
                            }
                            else
                            {
                                test.Rows[i]["UPDATE_PRIV"] = false;
                            }
                        }
                    }
                    if(test.Rows[i]["SELECT_PRIV"].ToString() == "")
                    {
                        test.Rows[i]["SELECT_PRIV"] = false;
                        test.Rows[i]["UPDATE_PRIV"] = false;
                    }
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void GrantSelectOnCol(string username, string tablename, List<string> SelectColumns)
        {
            try
            {
                string columns = "";
                for(int i = 0; i < SelectColumns.Count - 1; i++)
                {
                    columns += SelectColumns[i] + ", ";
                }
                if (SelectColumns.Count != 0)
                {
                    columns += SelectColumns[SelectColumns.Count - 1];
                    DAO_HospitalManagement.UserManagement.GrantSelectOnCol(username, tablename, columns);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void UpdateColumnPrivs(string username, string tablename, List<string> select, List<string> update)
        {
            //delete các dòng quyền trước
            try
            {                
                DAO_HospitalManagement.UserManagement.DeleteRows(username, tablename);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            int selectBit = 0;
            int updateBit = 0;

            for (int j=0; j < select.Count; j++)
            {
                for (int i = 0; i < update.Count; i++)
                {
                    //select & update
                    if (select[j] == update[i])
                    {
                        selectBit = 1;
                        updateBit = 1;
                        try
                        {
                            DAO_HospitalManagement.UserManagement.UpdateColumnPrivs(username, tablename, select[j], selectBit, updateBit);
                        }
                        catch(Exception ex)
                        {
                            throw ex;
                        }
                        update.Remove(update[i]);
                        i--;
                        select.Remove(select[j]);
                        j--;
                        break;
                    }
                }
            }

            //only select
            foreach (string columnname in select)
            {
                selectBit = 1;
                updateBit = 0;
                try
                {
                    DAO_HospitalManagement.UserManagement.UpdateColumnPrivs(username, tablename, columnname, selectBit, updateBit);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            //only update
            foreach (string columnname in update)
            {
                selectBit = 0;
                updateBit = 1;
                try
                {
                    DAO_HospitalManagement.UserManagement.UpdateColumnPrivs(username, tablename, columnname, selectBit, updateBit);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }

        }

        public static void GrantUpdateOnCol(string username, string tablename, string columnname)
        {
            try
            {
                DAO_HospitalManagement.UserManagement.GrantUpdateOnCol(username, tablename, columnname);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        static public void DeleteUser(string username)
        {
            DAO_HospitalManagement.UserManagement.DeleteUser(username);
        }

        static public DataTable GetAllUsers()
        {
            try
            {
                return DAO_HospitalManagement.UserManagement.GetAllUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ShowUserPrivs(string username)
        {
            try
            {
                return DAO_HospitalManagement.UserManagement.ShowUserPrivs(username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public void GrantSystemPrivileges(string username, string privileges, bool adminOption)
        {
            try
            {
                DAO_HospitalManagement.UserManagement.GrantSystemPrivileges(username, privileges, adminOption);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public void GrantObjectPrivileges(string username, string tableName, string privileges, bool adminOption)
        {
            try
            {
                DAO_HospitalManagement.UserManagement.GrantObjectPrivileges(username, tableName, privileges, adminOption);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <param name="privileges">Input privileges separated by comma</param>        
        static public void RevokeObjectPrivileges(string username, string tableName, string privileges)
        {
            try
            {
                DAO_HospitalManagement.UserManagement.RevokeObjectPrivileges(username, tableName, privileges);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <param name="privileges">Input privileges separated by comma</param>        
        static public void RevokeSystemPrivileges(string username, string privileges)
        {
            try
            {
                DAO_HospitalManagement.UserManagement.RevokeSystemPrivileges(username, privileges);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CheckUser(string username)
        {
            bool result = true;
            try
            {
                DataTable table = DAO_HospitalManagement.UserManagement.CheckUser(username);
                if (table.Rows.Count == 0)
                {
                    result = false;
                }
                else
                {
                    //do nothing
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void GrantRoleToUser(string rolename, string username)
        {
            try
            {
                DAO_HospitalManagement.UserManagement.GrantRoleToUser(rolename, username);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void RevokeRoleFromUser(string rolename, string username)
        {
            try
            {
                DAO_HospitalManagement.UserManagement.RevokeRoleFromUser(rolename, username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
