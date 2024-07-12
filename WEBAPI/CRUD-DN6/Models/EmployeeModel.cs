using CRUD_DN6.Enums;
using System.ComponentModel.DataAnnotations;

namespace CRUD_DN6.Models
{
    public class EmployeeModel
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public DepartmentEnum department { get; set; }
        public bool active { get; set; }
        public ShiftEnum shift { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime updatedAt { get; set; } = DateTime.Now.ToLocalTime();
    }
}
