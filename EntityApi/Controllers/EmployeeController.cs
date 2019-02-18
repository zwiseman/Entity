using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
            newOne.Id = 20;
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
    }
}