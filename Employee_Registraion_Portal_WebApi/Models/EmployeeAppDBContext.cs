using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;//this is required in scaffolding when we creating controller

namespace Employee_Registraion_Portal_WebApi.Models
{
    public class EmployeeAppDBContext : DbContext
    {
        public EmployeeAppDBContext(DbContextOptions<EmployeeAppDBContext> options) : base(options)
        {

        }

        public DbSet<Employee> ModelEmployees { get; set; }
    }
}
