using Sprout.Exam.DataAccess.Contracts;
using Sprout.Exam.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Services
{
    public class EmployeeService
    {
        private readonly EmployeeContract _employee;

        public EmployeeService(EmployeeContract employee)
        {
            _employee = employee;
        }
        /// <summary>
        /// GetEmployee By UserId
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>Employee</returns>
        public Task<Employee> GetEmployeeById(int employeeId)
        {
            return _employee.GetEmployeeById(employeeId);
        }
        /// <summary>
        /// Get All Employees
        /// </summary>
        /// <returns>IEnumerable<Employee></returns>
        public Task<IEnumerable<Employee>> GetAllEmployees()
        {
            try
            {
                return _employee.GetAllEmployees();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>bool</returns>
        public async Task<bool> AddEmployee(Employee employee)
        {
            return await _employee.AddEmployee(employee);
        }
        /// <summary>
        /// Delete Employee By Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>bool</returns>
        public async Task<bool> DeleteEmployeeById(int employeeId)
        {

            return await _employee.DeleteEmployeeById(employeeId);

        }
        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>bool</returns>
        public async Task<bool> UpdateEmployee(Employee employee)
        {
            return await _employee.UpdateEmployee(employee);
        }
    }
}
