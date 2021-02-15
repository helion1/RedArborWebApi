using RedArbor.Application.Services.DtoModels;
using RedArbor.Application.Services.Interfaces;
using RedArbor.Application.Services.Service;
using RedArbor.WebApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace RedArbor.WebApi.Controllers
{
    public class EmployeeApiController : ApiController
    {
        #region Contructor and properties
        private readonly IEmployeeService _employeeService;

        public EmployeeApiController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion


        #region GET
        /// <summary>
        /// Get all Employees
        /// </summary>
        /// <returns>Array of Employee</returns>
        [HttpGet]
        // GET api/EmployeeApi
        public HttpResponseMessage Get()
        {
            try
            {
                var allEmployees = _employeeService.GetAllEmployees();
                return Request.CreateResponse<EmployeeDto[]>(HttpStatusCode.OK, allEmployees);
            }
            catch (Exception)
            {
                return Request.CreateResponse<string>(HttpStatusCode.NotFound, ApiResources.ExceptionTableNotExists);
            }

        }

        /// <summary>
        /// Get an Employee by id
        /// </summary>
        /// <returns>Employee</returns>
        [HttpGet]
        // GET api/EmployeeApi/1
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var employee = _employeeService.GetEmployeeById(id);
                return Request.CreateResponse<EmployeeDto>(HttpStatusCode.OK, employee);
            }
            catch (Exception)
            {
                return Request.CreateResponse<string>(HttpStatusCode.NotFound, ApiResources.ExceptionEmployeeNotExists + id);
            }
        }
        #endregion

        #region POST
        /// <summary>
        /// Add a new Employee
        /// </summary>
        /// <returns>Employee</returns>
        // POST api/EmployeeApi
        [ResponseType(typeof(EmployeeDto))]
        public HttpResponseMessage Post([FromBody] EmployeeDto employeeNew)
        {
            try
            {
                var employee = _employeeService.AddEmployee(employeeNew);

                return Request.CreateResponse<EmployeeDto>(HttpStatusCode.Created, employee);
            }
            catch (Exception)
            {
                return Request.CreateResponse<string>(HttpStatusCode.Conflict, ApiResources.ExceptionEmployeeExists);
            }
        }
        #endregion

        #region PUT
        /// <summary>
        /// Update Employee's Username by id
        /// </summary>
        /// <returns>none</returns>
        // PUT api/EmployeeApi/5
        public HttpResponseMessage Put(int id,[FromBody] string username)
        {
            return _employeeService.UpdateEmployeeUsernameById(id, username) ?
                Request.CreateResponse(HttpStatusCode.OK) :
                Request.CreateResponse<string>(HttpStatusCode.NotFound, ApiResources.ExceptionEmployeeNotExists + id);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Delete an Employee by id
        /// </summary>
        /// <returns>none</returns>
        // DELETE api/EmployeeApi/5
        public HttpResponseMessage Delete(int id)
        {
            return _employeeService.DeleteEmployeeById(id) ? 
                Request.CreateResponse(HttpStatusCode.OK) : 
                Request.CreateResponse<string>(HttpStatusCode.NotFound, ApiResources.ExceptionEmployeeNotDeleted + id);
        }
        #endregion
    }
}
