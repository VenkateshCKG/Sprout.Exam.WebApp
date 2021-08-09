using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprout.Exam.DataAccess.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        public string FormattedBirthdate
        {
            get
            {
                return BirthDate.ToString("yyyy-MM-dd");
            }
        }
        public string TIN { get; set; }
        public int EmployeeTypeId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
