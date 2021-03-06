﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            Employee employee = repo.GetEmployee(id);
            return employee;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.DeleteEmployee(id);

        }
        [HttpPost]
        public void Post(string firstName, string lastName, DateTime birthDate, DateTime hireDate)
        {
            repo.CreateEmployee(firstName, lastName, birthDate, hireDate);
        }
    }
}
