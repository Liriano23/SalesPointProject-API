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
    public class ProductsController : ControllerBase
    {
        private readonly ProductsServices productsServices;

        public ProductsController(ProductsServices productsServices)
        {
            this.productsServices = productsServices;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var objProducts = await productsServices.GetAll();
            return Ok(objProducts);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Search(int id)
        {
            var obj = await productsServices.Search(id);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }


        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Products product)
        {
            if (await productsServices.Exist(product.ProductId))
            {
                ModelState.AddModelError("", "Product exist");
                return StatusCode(405, ModelState);

            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var objSuplier = await productsServices.Insert(product);

            if (!objSuplier)
            {
                ModelState.AddModelError("", $"An error occurs saving the product {product.ProductName}");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }


        // PUT api/<ProductsController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Products product)
        {
            if (await productsServices.Update(product))
            {
                ModelState.AddModelError("", "Product Updated");
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }


        // DELETE api/<ProductsController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var isDeleted = await productsServices.Delete(id);

            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                ModelState.AddModelError("", $"A Error occur Deleting the product with Id =  {id}");
                return StatusCode(404, ModelState);
            }
        }
    }
}
