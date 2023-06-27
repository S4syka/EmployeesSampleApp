using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    public Lazy<IEnumerable<Employee>> Employees();
}
