using Sprout.Exam.Business.DataTransferObjects;

using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Business.DataBusinessServices
{
    public class CalculateSalary
    {
        public static decimal RegularEmployee(CalculateEmployeeDto calculateEmployeeDto)
        {
            decimal totalAmount = decimal.Zero;
            const decimal monthlySalary = 20000;
            try
            {
                decimal findAbsentAmount = ((monthlySalary / 22) * calculateEmployeeDto.absentDays);
                decimal findWorkedAmount = (monthlySalary - findAbsentAmount);
                decimal findTaxAmount = findWorkedAmount * (decimal)0.12;
                totalAmount = Math.Round(monthlySalary - (findAbsentAmount + findTaxAmount), 2);
            }
            catch (Exception)
            {
                throw;
            }
            return totalAmount;
        }
        public static decimal ContractualEmployee(CalculateEmployeeDto calculateEmployeeDto)
        {
            decimal totalAmount = decimal.Zero;
            const decimal daySalary = 500;
            try
            {
                totalAmount = Math.Round(daySalary * calculateEmployeeDto.workedDays, 2);
            }
            catch (Exception)
            {

                throw;
            }
            return totalAmount;
        }
    }
}
