using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Services;
using backend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployersController : ControllerBase
    {
        private readonly EmployersServices employersServices;

        public EmployersController(EmployersServices employersServices)
        {
            this.employersServices = employersServices;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var objCategory = await employersServices.GetAll();
            return Ok(objCategory);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Search(int id)
        {
            var obj = await employersServices.Search(id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Employers employer)
        {
            if (await employersServices.Exist(employer.EmployerId))
            {
                ModelState.AddModelError("", "Employeer exist");
                return StatusCode(405, ModelState);

            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var objCategory = await employersServices.Insert(employer);

            if (!objCategory)
            {
                ModelState.AddModelError("", $"An error occurs saving the employer {employer.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

        // PUT api/<EmployersController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Employers employer)
        {
            if (await employersServices.Update(employer))
            {
                ModelState.AddModelError("", "Employer Updated");
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<EmployersController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var isDeleted = await employersServices.Delete(id);

            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                ModelState.AddModelError("", $"A Error occur deleting the employer with Id =  {id}");
                return StatusCode(404, ModelState);
            }
        }
    }
}
