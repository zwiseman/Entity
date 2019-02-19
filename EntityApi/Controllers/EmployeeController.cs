using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using EntityApi.Models;

namespace EntityApi {
    [Route ("employees")]
    [ApiController]
    public class EmployeeController {
        EntityContext entityContext = new EntityContext ();

        [HttpGet]
        public string Get () {
            List<Employees> employees = new List<Employees>();
            Employees newOne = new Employees();
            string prettyEmployees;
            newOne.LastName = "Mulaney";
            newOne.FirstName="John";
            newOne.Equipment = "Mic and Saltines";
            newOne.Job = "Comic";

            // entityContext.Employees.Add(newOne);
            // entityContext.SaveChanges();
            foreach (var employee in entityContext.Employees)
            {
                employees.Add(employee);
            }
            prettyEmployees = JsonConvert.SerializeObject(employees, Formatting.Indented);
            return prettyEmployees;
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