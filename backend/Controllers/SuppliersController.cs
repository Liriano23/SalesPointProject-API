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
    public class SuppliersController : ControllerBase
    {
        private readonly SupliersServices supliersServices;

        public SuppliersController(SupliersServices supliersServices)
        {
            this.supliersServices = supliersServices;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var objSupliers = await supliersServices.GetAll();
            return Ok(objSupliers);
        }

        // GET api/<SupliersController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Search(int id)
        {
            var obj = await supliersServices.Search(id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }


        // POST api/<SupliersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Suppliers suplier)
        {
            if (await supliersServices.Exist(suplier.SuplierId))
            {
                ModelState.AddModelError("", "Suplier exist");
                return StatusCode(405, ModelState);

            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var objSuplier = await supliersServices.Insert(suplier);

            if (!objSuplier)
            {
                ModelState.AddModelError("", $"An error occurs saving the Suplier {suplier.SuplierName}");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }


        // PUT api/<SupliersController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Suppliers suplier)
        {
            if (await supliersServices.Update(suplier))
            {
                ModelState.AddModelError("", "Suplier Updated");
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        // DELETE api/<SupliersController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var isDeleted = await supliersServices.Delete(id);

            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                ModelState.AddModelError("", $"A Error occur Deleting the suplier with Id =  {id}");
                return StatusCode(404, ModelState);
            }
        }
    }
}
