using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_HospitalManagement
{
    public class RoleManagement
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
            try
            {
                DAO_HospitalManagement.RoleManagement.CreateRole(roleName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public void DeleteRole(string roleName)
        {
            try
            {
                DAO_HospitalManagement.RoleManagement.DeleteRole(roleName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ShowRolePrivs(string role)
        {
            try
            {
                return DAO_HospitalManagement.RoleManagement.ShowRolePrivs(role);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public DataTable GetAllRoles()
        {
            try
            {
                return DAO_HospitalManagement.RoleManagement.GetAllRoles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public void GrantSystemPrivileges(string roleName, string privileges, bool adminOption)
        {
            try
            {
                DAO_HospitalManagement.RoleManagement.GrantSystemPrivileges(roleName,privileges,adminOption);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<string> GetAllTables()
        {
            List<string> result = new List<string>();

            DataTable dt = DAO_HospitalManagement.RoleManagement.GetAllTables();

            foreach(DataRow row in dt.Rows)
            {
                string name = row["TABLE_NAME"].ToString();
                result.Add(name);
            }

            return result;
        }

        static public void GrantObjectPrivileges(string roleName, string tableName, string privileges)
        {
            try
            {
                DAO_HospitalManagement.RoleManagement.GrantObjectPrivileges(roleName, tableName, privileges);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CheckRole(string rolename)
        {
            bool result = true;
            try
            {
                DataTable table = DAO_HospitalManagement.RoleManagement.CheckRole(rolename);
                if(table.Rows.Count == 0)
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

        /// <param name="privileges">Input privileges separated by comma</param>        
        static public void RevokeObjectPrivileges(string roleName, string tableName, string privileges)
        {
            try
            {
                DAO_HospitalManagement.RoleManagement.RevokeObjectPrivileges(roleName, tableName, privileges);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <param name="privileges">Input privileges separated by comma</param>        
        static public void RevokeSystemPrivileges(string roleName, string privileges)
        {
            try
            {
                DAO_HospitalManagement.RoleManagement.RevokeSystemPrivileges(roleName, privileges);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetRoleUsers(string rolename)
        {
            try
            {
                return DAO_HospitalManagement.RoleManagement.GetRoleUsers(rolename);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetUserDefaultRole()
        {
            string result = "";
            try
            {
                DataTable dt = DAO_HospitalManagement.RoleManagement.Instance.GetUserRoles();
                foreach (DataRow row in dt.Rows)
                {
                    string name = row["TABLE_NAME"].ToString();
                    //navigate roles
                    if (name == "DOCTOR")
                        return name;
                    else if (name == "DBA")
                        return name;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
