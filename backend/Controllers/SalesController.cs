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
    public class SalesController : ControllerBase
    {
        private readonly SalesServies salesServies;

        public SalesController(SalesServies salesServies)
        {
            this.salesServies = salesServies;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var objCategory = await salesServies.GetAll();
            return Ok(objCategory);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult> Search(int id)
        {
            var obj = await salesServies.Search(id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        // POST api/<SalesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Sales sale)
        {
            if (await salesServies.Exist(sale.SalesId))
            {
                ModelState.AddModelError("", "Sale exist");
                return StatusCode(405, ModelState);

            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var objCategory = await salesServies.Insert(sale);

            if (!objCategory)
            {
                ModelState.AddModelError("", $"An error occurs saving the sale {sale.SalesId}");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Sales sale)
        {
            if (await salesServies.Update(sale))
            {
                ModelState.AddModelError("", "sale Updated");
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var isDeleted = await salesServies.Delete(id);

            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                ModelState.AddModelError("", $"A Error occur deleting the sale with Id =  {id}");
                return StatusCode(404, ModelState);
            }
        }
    }
}
