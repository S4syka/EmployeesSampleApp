using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Employee: IEntity
    {
        public int Id { get; set; }

        [Required]
        public string? Firstname { get; set; }

        [Required]
        public string? Lastname { get; set; }

        [Required]
        public string? Profession { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public string? Status { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}\nFirstname:{Firstname}\nLastname:{Lastname}\nProfession:{Profession}\nSalary:{Salary}\nStatus:{Status}\nPhoneNumber:{PhoneNumber}";
        }
    }
}
