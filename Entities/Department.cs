using System.ComponentModel.DataAnnotations.Schema;
using Exam.Models;

namespace Exam.Entities
{
    [Table("Departments")]
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Location { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
