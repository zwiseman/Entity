using System;
using System.Collections.Generic;

namespace EntityApi.Models
{
    public partial class Employees
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Job { get; set; }
        public string Equipment { get; set; }
        public string Address { get; set; }
    }
}
