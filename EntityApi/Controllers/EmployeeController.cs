using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using EntityApi.Models;

namespace EntityApi {
    [Route ("employees/")]
    [ApiController]
    public class EmployeeController {
        EntityContext entityContext = new EntityContext ();

        [HttpGet]
        public List<Employees> Get () {
            List<Employees> employees = new List<Employees>();
            Employees newOne = new Employees();

            Console.WriteLine("We are in the employees get before the entity contet reference");
            foreach (var employee in entityContext.Employees)
            {
                employees.Add(employee);
                Console.WriteLine("we added an employee");
            }
            Console.WriteLine("We should return the employees");
            return employees;
        }

        [HttpPost]
        public void PostEmployee([FromBody]Employees employee) {
            entityContext.Employees.Add(employee);
            entityContext.SaveChanges();
        }

        [HttpPut]
        public void PutEmployee([FromBody]Employees employee) {
            entityContext.Update(employee);
            entityContext.SaveChanges();
        }

        [HttpPost("deleteEmployee")]
        public void DeleteEmployee([FromBody]Employees employee) {
            entityContext.Remove(employee);
            entityContext.SaveChanges();
        }
    }
}