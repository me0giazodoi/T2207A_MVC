using System;
using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Tên nhân viên là trường bắt buộc.")]
        public string EmployeeName { get; set; }

        public int DepartmentId { get; set; }

        public string Position { get; set; }
    }
}
