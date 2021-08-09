using Moq;
using Sprout.Exam.Business.Services;
using Sprout.Exam.DataAccess.Contracts;
using Sprout.Exam.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Sprout.Exam.UnitTest
{
    public class EmployeeUnitTestBusiness
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
            var userRepository = new Mock<EmployeeContract>();

            // Act
            userRepository.Setup(f => f.GetAllEmployees()).ReturnsAsync(EmployeeList);
            var userBusiness = new EmployeeService(userRepository.Object);
            var output = await userBusiness.GetAllEmployees();

            // Assert
            Assert.Equal(EmployeeList, output);

        }

        [Fact]
        public async Task GetAllEmployeeById_ReturnsEmployee()
        {
            // Arrange
            var userRepository = new Mock<EmployeeContract>();

            // Act
            userRepository.Setup(f => f.GetEmployeeById(2)).ReturnsAsync(Employee);
            var userBusiness = new EmployeeService(userRepository.Object);
            var output = await userBusiness.GetEmployeeById(2);

            // Assert
            Assert.Equal(Employee, output);
        }
        [Fact]
        public async Task DeleteEmployeeById_ReturnsTrue()
        {
            // Arrange
            var userRepository = new Mock<EmployeeContract>();

            // Act
            userRepository.Setup(f => f.DeleteEmployeeById(2)).ReturnsAsync(true);
            var userBusiness = new EmployeeService(userRepository.Object);
            var output = await userBusiness.DeleteEmployeeById(2);

            // Assert
            Assert.True(output);
        }
        [Fact]
        public async Task UpdateEmployee_ReturnsTrue()
        {
            // Arrange
            var userRepository = new Mock<EmployeeContract>();

            // Act
            userRepository.Setup(f => f.UpdateEmployee(Employee)).ReturnsAsync(true);
            var userBusiness = new EmployeeService(userRepository.Object);
            var output = await userBusiness.UpdateEmployee(Employee);

            // Assert
            Assert.True(output);
        }
        [Fact]
        public async Task AddEmployee_ReturnsTrue()
        {
            // Arrange
            var userRepository = new Mock<EmployeeContract>();

            // Act
            userRepository.Setup(f => f.AddEmployee(Employee)).ReturnsAsync(true);
            var userBusiness = new EmployeeService(userRepository.Object);
            var output = await userBusiness.AddEmployee(Employee);

            // Assert
            Assert.True(output);
        }
    }
}
