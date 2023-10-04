using System;
using System.ComponentModel.DataAnnotations;

namespace Exam.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Tên phòng ban là trường bắt buộc.")]
        public string DepartmentName { get; set; }

        public string Location { get; set; }

        [Display(Name = "Số lượng nhân viên")]
        public int EmployeeCount { get; set; }
    }
}
    