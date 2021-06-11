using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_HospitalManagement
{
    public class DTO_Dept
    {
        private string _deptName;
        private string _deptId;

        public string DeptName { get => _deptName; set => _deptName = value; }
        public string DeptId { get => _deptId; set => _deptId = value; }
    }
}
