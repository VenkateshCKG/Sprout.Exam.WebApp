using Sprout.Exam.DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Contracts
{
   public abstract class EmployeeContract
    {
        public abstract Task<IEnumerable<Employee>> GetAllEmployees();
        public abstract Task<Employee> GetEmployeeById(int employeeId);
        public abstract Task<bool> DeleteEmployeeById(int Id);
        public abstract Task<bool> UpdateEmployee(Employee employee);
        public abstract Task<bool> AddEmployee(Employee employee);
    }
}
