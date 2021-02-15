using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NSubstitute;
using RedArbor.Application.Services.DtoModels;
using RedArbor.Application.Services.Interfaces;
using RedArbor.Application.Services.Service;
using RedArbor.Infrastructure.Repository.Repository;
using RedArbor.WebApi;
using RedArbor.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Routing;

namespace RedArbor.WebApi.Tests.Controllers
{
    [TestClass()]
    public class EmployeeApiControllerTest
    {
        private EmployeeApiController controller;
        private IEmployeeService mockObject;

        private EmployeeDto employee1;
        private EmployeeDto employee2;
        private EmployeeDto employee3;

        private EmployeeDto[] employeeArray;

        [TestInitialize]
        public void Setup()
        {
            controller = new EmployeeApiController(new EmployeeService(new EmployeeRepository()));
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            #region Employees instances
            employee1 = new EmployeeDto(1,
                                    Convert.ToDateTime("2000-01-01 00:00:00"),
                                    Convert.ToDateTime("2000-01-01 00:00:00"),
                                    "test1@test.test.tmp",
                                    "000.000.000",
                                    "test1",
                                    Convert.ToDateTime("2000-01-01 00:00:00"),
                                    "test",
                                    1,
                                    1,
                                    1,
                                    "000.000.000",
                                    Convert.ToDateTime("2000-01-01 00:00:00"),
                                    "test1"
                                    );

            employee2 = new EmployeeDto(2,
                                    Convert.ToDateTime("2000-01-01 00:00:00"),
                                    Convert.ToDateTime("2000-01-01 00:00:00"),
                                    "test2@test.test.tmp",
                                    "000.000.000",
                                    "test2",
                                    Convert.ToDateTime("2000-01-01 00:00:00"),
                                    "test",
                                    2,
                                    2,
                                    2,
                                    "000.000.000",
                                    Convert.ToDateTime("2000-01-01 00:00:00"),
                                    "test2"
                                    );

            employee3 = new EmployeeDto(3,
                                    Convert.ToDateTime("2000-01-01 00:00:00"),
                                    Convert.ToDateTime("2000-01-01 00:00:00"),
                                    "test3@test.test.tmp",
                                    "000.000.000",
                                    "test3",
                                    Convert.ToDateTime("2000-01-01 00:00:00"),
                                    "test",
                                    3,
                                    3,
                                    3,
                                    "000.000.000",
                                    Convert.ToDateTime("2000-01-01 00:00:00"),
                                    "test3"
                                    );
            #endregion

            employeeArray = new EmployeeDto[3] { employee1, employee2, employee3 };
        }

        #region GET BY ID - Integration
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

        #region GET BY ID
        [TestMethod]
        public void GetByIdTest()
        {
            //Setup
            var mock = new Mock<IEmployeeService>();
            mock.Setup(x => x.GetEmployeeById(1)).Returns(employee1);
            mockObject = mock.Object;

            //Act
            var result = mockObject.GetEmployeeById(1);

            //Assert
            Assert.AreEqual(result, employee1);
        }
        #endregion

        #region GET ALL
        [TestMethod]
        public void GetAllEmployeesTest()
        {
            //Setup
            var mock = new Mock<IEmployeeService>();
            mock.Setup(x => x.GetAllEmployees()).Returns(employeeArray);
            mockObject = mock.Object;

            //Act
            var result = mockObject.GetAllEmployees();

            //Assert
            Assert.AreEqual(result.Length, employeeArray.Length);
            Assert.AreEqual(result[0].CompanyId, employeeArray[0].CompanyId);
            Assert.AreEqual(result[1].Email, employeeArray[1].Email);
            Assert.AreEqual(result[2].Username, employeeArray[2].Username);
            Assert.AreEqual(result[1], employeeArray[1]);
        }
        #endregion

        #region POST
        [TestMethod]
        public void PostTest()
        {
            //Setup
            var mock = new Mock<IEmployeeService>();
            mock.Setup(x => x.AddEmployee(employee1)).Returns(employee1);
            mockObject = mock.Object;

            //Act
            var result = mockObject.AddEmployee(employee1);

            //Assert
            Assert.AreEqual(result, employee1);
        }
        #endregion

        #region PUT
        [TestMethod]
        public void PutTest()
        {
            //Setup
            var mock = new Mock<IEmployeeService>();
            mock.Setup(x => x.UpdateEmployeeUsernameById(1, "test1updated")).Returns(true);
            mockObject = mock.Object;

            //Act
            var result = mockObject.UpdateEmployeeUsernameById(1, "test1updated");

            //Assert
            Assert.IsTrue(result);
        }
        #endregion

        #region DELETE
        [TestMethod]
        public void DeleteTest()
        {
            //Setup
            var mock = new Mock<IEmployeeService>();
            mock.Setup(x => x.DeleteEmployeeById(1)).Returns(true);
            mockObject = mock.Object;

            //Act
            var result = mockObject.DeleteEmployeeById(1);

            //Assert
            Assert.IsTrue(result);
        }
        #endregion
    }
}
