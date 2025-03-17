using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDOperationMVC.Models
{
    public class EmployeeD
    {
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public int[] LoopingValue { get; set; }
    }
}