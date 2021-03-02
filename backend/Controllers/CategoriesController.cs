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
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryServices categoryServices;

        public CategoriesController(CategoryServices categoryservices)
        {
            this.categoryServices = categoryservices;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var objCategory = await categoryServices.GetAll();
            return Ok(objCategory);
        }

        
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Search(int id)
        {
            var obj = await categoryServices.Search(id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Categories category)
        {
            if (await categoryServices.Exist(category.CategoryId) )
            {
                ModelState.AddModelError("", "Category exist");
                return StatusCode(405, ModelState);

            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var objCategory = await categoryServices.Insert(category);

            if (!objCategory)
            {
                ModelState.AddModelError("", $"An error occurs saving the category {category.CategoryName}");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Categories category)
        {
            if (await categoryServices.Update(category))
            {
                ModelState.AddModelError("", "Category Updated");
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
            var isDeleted = await categoryServices.Delete(id);

            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                ModelState.AddModelError("", $"A Error occur deleting the category with Id =  {id}");
                return StatusCode(404, ModelState);
            }
        }
    }
}
