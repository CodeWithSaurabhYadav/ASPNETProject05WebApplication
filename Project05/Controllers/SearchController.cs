using Microsoft.AspNetCore.Mvc;
using Project05.Data;
using Project05.Models;

namespace Project05.Controllers
{
    public class SearchController : Controller
    {
        private EmployeeContext _employeeContext;

        public SearchController(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public IActionResult Index()
        {
            IEnumerable<EmployeeModel> Employees = _employeeContext.Employees;
            var employeeId = TempData["EmployeeId"];
            ViewBag.Message = employeeId;
            return View(Employees);
        }
    }
}
