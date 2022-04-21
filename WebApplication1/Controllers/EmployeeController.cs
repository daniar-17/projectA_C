using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using WebApplication1.Models;
using System.Web;

namespace WebApplication1.Controllers
{
    public class EmployeeController : ApiController
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
            string query = @"select EmployeeId, EmployeeName, Department, convert(varchar(10), DateOfJoining, 120) as DateOfJoining, PhotoFileName from dbo.Employee";
            DataTable table = connect(query);
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Employee emp)
        {
            try
            {
                string query = @"insert into dbo.Employee values (
                '" + emp.EmployeeName + @"'
                ,'" + emp.Department + @"'
                ,'" + emp.DateOfJoining + @"'
                ,'" + emp.PhotoFileName + @"'
                )";
                DataTable table = connect(query);
                return "Added Successfully!!";

            }
            catch (Exception e)
            {
                return "Failed to Add!! : " + e;
            }
        }

        public string Put(Employee emp)
        {
            try
            {
                string query = @"update dbo.Employee set 
                EmployeeName = '" + emp.EmployeeName + @"' 
                ,Department = '" + emp.Department + @"' 
                ,DateOfJoining = '" + emp.DateOfJoining + @"' 
                ,PhotoFileName = '" + emp.PhotoFileName + @"' 
                where EmployeeId = " + emp.EmployeeId + @"";
                DataTable table = connect(query);
                return "Update Successfully!!";

            }
            catch (Exception e)
            {
                return "Failed to Update!! : " + e;
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"delete dbo.Employee where EmployeeId = " + id + @"";
                DataTable table = connect(query);
                return "Delete Successfully!!";

            }
            catch (Exception e)
            {
                return "Failed to Delete!! : " + e;
            }
        }

        [Route("api/Employee/GetAllDepartmentNames")]
        [HttpGet]
        public HttpResponseMessage GetAllDepartmentNames()
        {
            try
            {
                string query = @"select DepartmentName from dbo.Department";
                DataTable table = connect(query);
                return Request.CreateResponse(HttpStatusCode.OK, table);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e);
            }
        }

        [Route("api/Employee/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPatch = HttpContext.Current.Server.MapPath("~/Photos/" + fileName);
                postedFile.SaveAs(physicalPatch);
                return fileName;
            }
            catch (Exception e)
            {
                return "anonymous.png";
            }
        }
    }
}
