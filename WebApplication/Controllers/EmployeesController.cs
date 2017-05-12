using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlRepository;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        Repository repo;

        public EmployeesController()
        {
            repo = new Repository();
        }
        [HttpGet]
        public List<Employee> GetAllEmployees()
        {
            return repo.GetAllEmployees();
        }
    }
}
