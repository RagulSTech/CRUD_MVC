using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDOperationMVC.Models
{
    public class EmployeePortal
    {
        public EmployeeD employee { get; set; }
        public List<EmployeeD> employeeL { get; set; }
        public Dictionary<int, EmployeeD> employeeD { get; set; }
    }
}