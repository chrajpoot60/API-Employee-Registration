using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee_Registraion_Portal_WebApi.Models;

namespace Employee_Registraion_Portal_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesAPIController : ControllerBase
    {
        private readonly EmployeeAppDBContext _context;

        public EmployeesAPIController(EmployeeAppDBContext context)
        {
            _context = context;
        }

        // GET: api/EmployeesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetModelEmployees()
        {
            return await _context.ModelEmployees.FromSqlRaw("select *from ModelEmployees where IsActive = 1").ToListAsync();
            //return await _context.ModelEmployees.ToListAsync();
        }

        // GET: api/EmployeesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.ModelEmployees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/EmployeesAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmpId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployeesAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            //use for filtering the DateOfBirth coming from front-end(Angular)
            //string[] date = employee.DateOfBirth.Split("T");
            //employee.DateOfBirth = date[0];
            _context.ModelEmployees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.EmpId }, employee);
        }

        // DELETE: api/EmployeesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.ModelEmployees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            //_context.ModelEmployees.Remove(employee);
            //_context.ModelEmployees.FromSqlRaw("update ModelEmployees Set Status = 0 where EmpId = " + id);

            employee.IsActive = 0;
            _context.ModelEmployees.Update(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.ModelEmployees.Any(e => e.EmpId == id);
        }
    }
}
