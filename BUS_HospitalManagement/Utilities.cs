using DAO_HospitalManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_HospitalManagement
{
    public class Utilities
    {
        static public void Login(string username, string password)
        {
            try
            {
                DBConnect connect = new DBConnect(username, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
