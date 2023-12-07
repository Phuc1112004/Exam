using Microsoft.AspNetCore.Mvc;
using Exam.Models;
using Exam.Entities;

namespace Exam.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }
        
        public ActionResult Index()
        {
            List<EmployeeModel> employeeModels = _context.Employees
        .Select(e => new EmployeeModel
        {
            Id = e.Id,
            Name = e.Name,
            Code = e.Code,
            Rank = e.Rank,
            DepartmentId = e.DepartmentId
        })
        .ToList();
            return View(employeeModels);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {

                
                _context.Employees.Add(new Employee
                {
                    Name = model.Name,
                    Code = model.Code,
                    Rank = model.Rank,
                    DepartmentId = model.DepartmentId
                });
                _context.SaveChanges();

                
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee employee = _context.Employees.Find(id);
            if (employee == null)
                return NotFound();

            // Assuming you have an EmployeeModel that corresponds to the Employee entity
            return View(new EmployeeModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Code = employee.Code,
                Rank = employee.Rank,
                DepartmentId = employee.DepartmentId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                Employee existingEmployee = _context.Employees.Find(model.Id);
                if (existingEmployee == null)
                    return NotFound();

                // Update the properties of existingEmployee with the values from model
                existingEmployee.Name = model.Name;
                existingEmployee.Code = model.Code;
                existingEmployee.Rank = model.Rank;
                existingEmployee.DepartmentId = model.DepartmentId;

                _context.Employees.Update(existingEmployee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Employee employee = _context.Employees.Find(id);
            if (employee == null)
                return NotFound();

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
