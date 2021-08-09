using Sprout.Exam.Business.DataTransferObjects;

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Contracts
{
    public interface IEmployeeContracts
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployees();
        Task<EmployeeDto> GetEmployeeID(int employeeId);
        Task<HttpStatusCode> DeleteProduct(int Id);
        Task<HttpStatusCode> UpdateProduct(EmployeeDto employee);
        Task<HttpStatusCode> AddProduct(EmployeeDto employee);
    }
}
