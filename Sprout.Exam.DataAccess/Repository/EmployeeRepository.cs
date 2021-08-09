using Microsoft.EntityFrameworkCore;
using Sprout.Exam.DataAccess.Contracts;
using Sprout.Exam.DataAccess.Data;
using Sprout.Exam.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Repository
{
    public class EmployeeRepository : EmployeeContract
    {
        private readonly EmployeeDbContext _context;
        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public override async Task<bool> AddEmployee(Employee employee)
        {
            bool isEmployeeAdded = false;
            try
            {

                if (!string.IsNullOrEmpty(employee.FullName))
                {
                    _context.employee.Add(employee);
                    await _context.SaveChangesAsync();
                    isEmployeeAdded = true;
                }
                else
                {
                    isEmployeeAdded = false;
                }
            }
            catch (Exception)
            {
                isEmployeeAdded = false;
            }
            return isEmployeeAdded;
        }
        /// <summary>
        /// Delete Employee By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public override async Task<bool> DeleteEmployeeById(int Id)
        {
            bool isEmployeeDeleted = false;
            try
            {
                Employee product = await _context.employee.FindAsync(Id);
                if (product != null)
                {
                    _context.employee.Remove(product);
                    await _context.SaveChangesAsync();
                    isEmployeeDeleted = true;
                }
                else
                {
                    isEmployeeDeleted = false;
                }

            }
            catch (Exception)
            {
                isEmployeeDeleted = false;
            }
            return isEmployeeDeleted;
        }
        /// <summary>
        /// Get All Employees
        /// </summary>
        /// <returns>Employees</returns>
        public override async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await Task.FromResult(_context.employee);
        }
        /// <summary>
        /// Get Employee By Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public override async Task<Employee> GetEmployeeById(int employeeId)
        {
            var employee = (from item in _context.employee where item.Id == employeeId select item).SingleOrDefaultAsync();
            return await employee;
        }
        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public override async Task<bool> UpdateEmployee(Employee employee)
        {
            bool isEmployeeUpdated = false;
            try
            {
                var productFromDb = _context.employee.Where(x => x.Id == employee.Id);
                if (productFromDb.Count() > 0)
                {
                    if (productFromDb != null)
                    {
                        _context.Entry(employee).State = EntityState.Detached;
                    }
                    _context.Entry(employee).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    isEmployeeUpdated = true;
                }
                else
                {
                    isEmployeeUpdated = false;
                }

            }
            catch (Exception)
            {
                isEmployeeUpdated = false;
            }
            return isEmployeeUpdated;
        }
    }
}
