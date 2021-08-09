using FluentValidation;
using Sprout.Exam.DataAccess.Models;

namespace Sprout.Exam.WebApp.FluentValidation
{
    public class EmployeeValidator  : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(p => p.FullName).NotEmpty().WithMessage("{PropertyName} should be not empty."); 
            RuleFor(p => p.BirthDate).NotEmpty().WithMessage("{PropertyName} should be not empty."); 
            RuleFor(p => p.TIN).NotEmpty().WithMessage("{PropertyName} should be not empty."); 
            RuleFor(p => p.EmployeeTypeId).NotEmpty().WithMessage("{PropertyName} should be not empty."); 
        }
    }
}
