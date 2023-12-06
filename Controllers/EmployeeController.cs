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
        // GET: DepartmentController1
        public ActionResult Index()
        {
            List<Employee> ls = _context.Employees.ToList();
            return View(ls);
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

                // save to db
                _context.Employees.Add(new Employee
                {
                    Name = model.Name,
                    Code = model.Code,
                    Rank = model.Rank,
                    DepartmentId = model.DepartmentId
                });
                _context.SaveChanges();

                // redirect to list
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
