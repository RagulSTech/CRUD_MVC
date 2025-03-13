using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CRUDOperationMVC.Models;

namespace CRUDOperationMVC.Controllers
{
    public class EmployeePortalController : Controller
    {
        private string connectionstring_;
        public EmployeePortalController()
        {
            connectionstring_ = ConfigurationManager.ConnectionStrings["connection_Db"].ConnectionString;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(string alertdata)
        {
            List<Models.employeedetails> employeeList = TempData["EmployeeList"] as List<Models.employeedetails>;
            
            if (alertdata != null) 
            { 
                ViewData["AlterMsg"] = alertdata;
            }
            using (SqlConnection con = new SqlConnection(connectionstring_))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeRead", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empno", "View");
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                ViewData["Datatablereturn"] = dt;
            }
            return View(employeeList);
        }
        public ActionResult CreateInsert(string username, string email, string Udate, string phno)
        {
            using (SqlConnection con = new SqlConnection(connectionstring_))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeInsert",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empusername", username);
                cmd.Parameters.AddWithValue("@empemail", email);
                cmd.Parameters.AddWithValue("@empdob", Udate);
                cmd.Parameters.AddWithValue("@empphoneno", phno);
                cmd.Parameters.AddWithValue("@empno", 0);
                //int result = cmd.ExecuteNonQuery();
                //if (result != 0)
                //{
                //    return RedirectToAction("Create","EmployeePortal");
                //}
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                return RedirectToAction("Create", "EmployeePortal",new {alertdata = dt.Rows[0]["Result"].ToString() });
            }
        }
        public ActionResult Read()
        {
             return View();
        }
        public ActionResult ViewDetails()
        {
            return View();
        }
        public ActionResult Update(string empno)
        {
            List<Models.employeedetails> emplist = new List<Models.employeedetails>();
            using (SqlConnection con = new SqlConnection(connectionstring_))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("EmployeeRead", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empno", empno);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    employeedetails emp = new employeedetails()
                    {
                        empnoId = int.Parse(row["empno"].ToString()),
                        empusername = row["empusername"].ToString(),
                        empemail = row["empemail"].ToString(),
                        empdob = row["empdob"].ToString(),
                        empphono = row["empphono"].ToString(),
                    };
                    emplist.Add(emp);
                }
            }
            ViewData["EmployeeList"] = emplist;
            return RedirectToAction("Create", "EmployeePortal");
        }
    }
}