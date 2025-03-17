using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDOperationMVC.Models;

namespace CRUDOperationMVC.Controllers
{
    public class OopsController : Controller
    {
        // GET: Oops
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmployeeDetails()
        {
            EmployeeD employee = new EmployeeD();
            employee.emp_id = 1;
            employee.emp_name = "Rooban";

            List<EmployeeD> employeeL = new List<EmployeeD>()
            {
                new EmployeeD { emp_id= 1, emp_name = "Ragul"},
                new EmployeeD { emp_id= 2, emp_name = "Mani"},
            };

            Dictionary<int, EmployeeD> employeeD = new Dictionary<int, EmployeeD>()
            {
                {1, new EmployeeD{emp_id =1 , emp_name = "Venki"} },
                {2, new EmployeeD{emp_id =2 , emp_name = "Karthi"} },
            };

            EmployeePortal employeePortal = new EmployeePortal()
            {
                employee = employee,
                employeeL = employeeL,
                employeeD = employeeD,
            };

            return View(employeePortal);
        }
        public ActionResult LoopingValues()
        {
            int[] arr = {1,2,3,4,5,6,7};
            EmployeeD Loopvalue = new EmployeeD();
            Loopvalue.LoopingValue = new int[arr.Length];
            int count = 0;
            int[] final_arr = new int[arr.Length];



            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i]+arr[j] == 8)
                    {
                        if(!(final_arr.Contains(arr[i]) || final_arr.Contains(arr[j]))){
                            final_arr[count++] = arr[i];
                            final_arr[count++] = arr[j];
                        }
                    }
                }
            }
            Array.Sort(final_arr);
            List<int> final_array = new List<int>(final_arr);
            final_array.RemoveAll(x => x == 0);
            
            return View(final_array);
        }

        public ActionResult Banking()
        {
            return View();
        }
    }
}