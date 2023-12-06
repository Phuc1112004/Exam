using Exam.Controllers;
using Exam.Models;
using Exam.Repositories;
using Exam.Services;
using Exam.Repositories;

namespace Exam.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _departmentRepository.GetAllDepartments();
        }
    }
}
