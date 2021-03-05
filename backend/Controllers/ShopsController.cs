using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Services;
using backend.Models;
namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : Controller
    {
        private readonly ShopServices shopsServices;

        public ShopsController(ShopServices shopsServices)
        {
            this.shopsServices = shopsServices;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var objCategory = await shopsServices.GetAll();
            return Ok(objCategory);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult> Search(int id)
        {
            var obj = await shopsServices.Search(id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        // POST api/<SalesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Shops shop)
        {
            if (await shopsServices.Exist(shop.ShopId))
            {
                ModelState.AddModelError("", "Shop exist");
                return StatusCode(405, ModelState);

            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var objCategory = await shopsServices.Insert(shop);

            if (!objCategory)
            {
                ModelState.AddModelError("", $"An error occurs saving the sale {shop.ShopId}");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Shops shop)
        {
            if (await shopsServices.Update(shop))
            {
                ModelState.AddModelError("", "Shop Updated");
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
            var isDeleted = await shopsServices.Delete(id);

            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                ModelState.AddModelError("", $"A Error occur deleting the Shop with Id =  {id}");
                return StatusCode(404, ModelState);
            }
        }
    }
}
