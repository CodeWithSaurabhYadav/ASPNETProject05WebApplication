using System.ComponentModel.DataAnnotations;

namespace Project05.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        public String EmpName { get; set; }
        [Required]
        public String Address { get; set; }
    }
}
