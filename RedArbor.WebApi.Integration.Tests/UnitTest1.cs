using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedArbor.Application.Services.DtoModels;
using RedArbor.Application.Services.Service;
using RedArbor.Infrastructure.Repository.Repository;
using RedArbor.WebApi.Controllers;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedArbor.WebApi.Integration.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private EmployeeApiController controller;

        [TestInitialize]
        public void Setup()
        {
            controller = new EmployeeApiController(new EmployeeService(new EmployeeRepository()));
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
        }

        #region GET BY ID -
        [TestMethod]
        public void GetByIdTestOk()
        {
            //Act
            HttpResponseMessage result = controller.Get(0);

            //Assert
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
            Assert.IsTrue(result.TryGetContentValue(out EmployeeDto employee));
            Assert.AreEqual(employee.CompanyId, 0);
        }

        [TestMethod]
        public void GetByIdTestNotFound()
        {
            //Act
            HttpResponseMessage result = controller.Get(99);

            //Assert
            Assert.AreEqual(result.StatusCode, HttpStatusCode.NotFound);
            Assert.IsFalse(result.TryGetContentValue(out EmployeeDto _));
        }
        #endregion
    }
}
