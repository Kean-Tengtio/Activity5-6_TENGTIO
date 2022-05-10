using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Activity5_6_TENGTIO.Models;

namespace Activity5_6_TENGTIO.Controllers
{
    [Authorize]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Index()
        {
            try
            {
                IPTEntities db = new IPTEntities();
                var employees = db.Employees;
                var response = Request.CreateResponse<IEnumerable<Employee>>(HttpStatusCode.OK, employees);
                return response;
            }
            catch (Exception ex)
            {
                var errorresponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                return errorresponse;
            }
        }

        [HttpGet]
        public HttpResponseMessage Index(int id)
        {
            try
            {
                IPTEntities db = new IPTEntities();
                var employee = db.Employees.Where(m=>m.EmployeeId==id).FirstOrDefault();
                if (employee == null)
                    throw new Exception("Employee ID not found");
                var response = Request.CreateResponse<Employee>(HttpStatusCode.OK, employee);
                return response;
            }
            catch (Exception ex)
            {
                var errorresponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                return errorresponse;
            }
        }
    }
}
