using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjADODotNET.Models
{
    public class ViewModelDepEmpByDep
    {
        public List<tDepartment> department { get; set; }
        public List<tEmployeeResult> employee { get; set; }
    }

    public class ViewModelDepEmpByEmp
    {
        public List<tDepartment>  department { get; set; }
        public tEmployee employee { get; set; }
    }
}