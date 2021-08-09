using Microsoft.AspNetCore.Mvc;
using Moq;
using Sprout.Exam.Business.Services;
using Sprout.Exam.DataAccess.Contracts;
using Sprout.Exam.DataAccess.Models;
using Sprout.Exam.WebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Sprout.Exam.UnitTest
{
    public class EmployeeUnitTestWebAPI
    {
        #region Mock Objects

        IEnumerable<Employee> EmployeeList = new List<Employee>()
        {
            new Employee()
            {
                BirthDate = DateTime.Now,
                FullName = "Jane Doe",
                Id = 1,
                TIN = "123215413",
                EmployeeTypeId = 1
            },
            new Employee()
            {
                BirthDate = DateTime.Now,
                FullName = "Venkatesh C",
                Id = 2,
                TIN = "957125412",
                EmployeeTypeId = 2
            }
        };

        Employee Employee = new Employee()
        {
            BirthDate = DateTime.Now,
            FullName = "Venkatesh C",
            Id = 2,
            TIN = "957125412",
            EmployeeTypeId = 2
        };

        #endregion

        [Fact]
        public async Task GetAllEmployee_ReturnsEmployees()
        {
            // Arrange
            var employeeRepository = new Mock<EmployeeContract>();
            employeeRepository.Setup(f => f.GetAllEmployees()).ReturnsAsync(EmployeeList);
            var employeeService = new Mock<EmployeeService>(employeeRepository.Object);

            // Act
            var employeeController = new EmployeesController(employeeService.Object);
            var output = await employeeController.Get();

            // Assert
            var okResult = output as OkObjectResult;
            Assert.Equal(EmployeeList, okResult.Value);
        }

        [Fact]
        public async Task GetAllEmployeeById_ReturnsEmployee()
        {
            // Arrange
            var employeeRepository = new Mock<EmployeeContract>();
            employeeRepository.Setup(f => f.GetEmployeeById(1)).ReturnsAsync(Employee);
            var employeeService = new Mock<EmployeeService>(employeeRepository.Object);

            // Act
            var employeeController = new EmployeesController(employeeService.Object);
            var output = await employeeController.GetById(1);

            // Assert
            var okResult = output as OkObjectResult;
            Assert.Equal(Employee, okResult.Value);
        }
        [Fact]
        public async Task DeleteEmployeeById_ReturnsTrue()
        {
            // Arrange
            var employeeRepository = new Mock<EmployeeContract>();
            employeeRepository.Setup(f => f.DeleteEmployeeById(1)).ReturnsAsync(true);
            var employeeService = new Mock<EmployeeService>(employeeRepository.Object);

            // Act
            var employeeController = new EmployeesController(employeeService.Object);
            var output = await employeeController.Delete(1);

            // Assert
            var okResult = output as OkObjectResult;
            Assert.Equal(1, okResult.Value);


        }
        [Fact]
        public async Task UpdateEmployee_ReturnsTrue()
        {
            // Arrange
            var employeeRepository = new Mock<EmployeeContract>();
            employeeRepository.Setup(f => f.UpdateEmployee(Employee)).ReturnsAsync(true);
            var employeeService = new Mock<EmployeeService>(employeeRepository.Object);

            // Act
            var employeeController = new EmployeesController(employeeService.Object);
            var output = await employeeController.Put(Employee);

            // Assert
            var okResult = output as OkObjectResult;
            Assert.Equal(Employee, okResult.Value);
        }
        [Fact]
        public async Task AddEmployee_ReturnsTrue()
        {
            // Arrange
            var employeeRepository = new Mock<EmployeeContract>();
            employeeRepository.Setup(f => f.AddEmployee(Employee)).ReturnsAsync(true);
            var employeeService = new Mock<EmployeeService>(employeeRepository.Object);

            // Act
            var employeeController = new EmployeesController(employeeService.Object);
            var output = await employeeController.Post(Employee);

            // Assert
            var okResult = output as CreatedResult;
            Assert.Equal(Employee, okResult.Value);
        }
    }
}
