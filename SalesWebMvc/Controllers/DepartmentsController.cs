using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers;
public class DepartmentsController : Controller
{
    public IActionResult Index()
    {
        List<Department> departments =
        [
            new Department { Id = 1, Name= "Eletronics" },
            new Department { Id = 2, Name= "Fashion" },
        ];

        return View(departments);
    }
}
