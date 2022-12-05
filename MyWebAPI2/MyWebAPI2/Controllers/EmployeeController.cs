using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI2.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {

        List<Employee> emplist = new List<Employee>()
            {
                 new Employee(){Empid = 1 ,Name = "Swapnil"},
                  new Employee(){Empid = 2 ,Name = "Samir"},
                   new Employee(){Empid = 3 ,Name = "Kamlesh"},
            };


        [Route("Employees")]
        public IActionResult Get()
        {

            return Ok(emplist);
        }

        //[Route("Employees/{id:int}")]
        //public Employee Get(int id)
        //{

        //    return emplist.Where(emp => emp.Empid == id).FirstOrDefault();
        //}

        [Route("Employees/{id:int}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return NotFound("Invalid Employee ID");
            }
            else
            {
                return Ok(emplist.Where(emp => emp.Empid == id).FirstOrDefault());
            }
        }

        [Route("Employees/{id:int}/basic")]
        public ActionResult<Employee> Getbasic(int id)
        {
            if (id <= 0)
            {
                return NotFound("Invalid Employee ID");
            }
            else
            {
                return emplist.Where(emp => emp.Empid == id).FirstOrDefault();
            }
        }

        [HttpPost]
        [Route("Employees")]
        public IActionResult AddEmployee(Employee emp)
        {
            if (emp != null)
            {
                return BadRequest();
            }
            else
            {
                emplist.Add(emp);

                return Created("/api/Employees/Employees", new Employee() { Empid = emp.Empid} );
            }
        }
    }
}
