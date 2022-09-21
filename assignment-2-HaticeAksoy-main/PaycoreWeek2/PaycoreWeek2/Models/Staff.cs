using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaycoreWeek2.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Salary { get; set; }
    }
}
