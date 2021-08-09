using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.Business.DataBusinessServices;
using Sprout.Exam.DataAccess.Models;
using Sprout.Exam.Business.Services;

namespace Sprout.Exam.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            return Ok(employee);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and update changes to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Employee employee)
        {
            if (await _employeeService.UpdateEmployee(employee))
            {
                return Ok(employee);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Refactor this method to go through proper layers and insert employees to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Employee employee)
        {
            if (await _employeeService.AddEmployee(employee))
            {
                return Created($"/api/employees", employee);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Refactor this method to go through proper layers and perform soft deletion of an employee to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _employeeService.DeleteEmployeeById(id))
            {
                return Ok(id);
            }
            else
            {
                return NotFound();
            }

        }

        /// <summary>
        /// Refactor this method to go through proper layers and use Factory pattern
        /// </summary>
        /// <param name="id"></param>
        /// <param name="absentDays"></param>
        /// <param name="workedDays"></param>
        /// <returns></returns>
        [HttpPost("{id}/calculate")]
        public async Task<IActionResult> Calculate(CalculateEmployeeDto calculateEmployeeDto)
        {
            var result = await _employeeService.GetEmployeeById(calculateEmployeeDto.Id);

            if (result == null) return NotFound();
            var type = (EmployeeType)result.EmployeeTypeId;
            return type switch
            {
                EmployeeType.Regular =>
                    //create computation for regular.
                    Ok(CalculateSalary.RegularEmployee(calculateEmployeeDto)),
                EmployeeType.Contractual =>
                    //create computation for contractual.
                    Ok(CalculateSalary.ContractualEmployee(calculateEmployeeDto)),
                _ => NotFound("Employee Type not found")
            };

        }
    }
}
