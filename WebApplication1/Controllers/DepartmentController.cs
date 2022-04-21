using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Net.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DepartmentController : ApiController
    {
        public DataTable connect(string query) 
        {
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return table;
        }

        // GET: Department
        public HttpResponseMessage Get()
        {
            string query = @"select DepartmentId, DepartmentName from dbo.Department";
            DataTable table = connect(query);
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Department dep)
        {
            try
            {
                string query = @"insert into dbo.Department values ('" + dep.DepartmentName + @"')";
                DataTable table = connect(query);
                return "Added Successfully!!";

            }
            catch (Exception)
            {
                return "Failed to Add!!";
            }
        }

        public string Put(Department dep)
        {
            try
            {
                string query = @"update dbo.Department set DepartmentName = '" + dep.DepartmentName + @"' where DepartmentId = "+dep.DepartmentId+@"";
                DataTable table = connect(query);
                return "Update Successfully!!";

            }
            catch (Exception)
            {
                return "Failed to Update!!";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"delete dbo.Department where DepartmentId = " + id + @"";
                DataTable table = connect(query);
                return "Delete Successfully!!";

            }
            catch (Exception)
            {
                return "Failed to Delete!!";
            }
        }
    }
}