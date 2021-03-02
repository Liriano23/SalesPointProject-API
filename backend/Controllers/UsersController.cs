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
    public class UsersController : ControllerBase
    {
        private readonly UsersServices usersServices;

        public UsersController(UsersServices usersServices)
        {
            this.usersServices = usersServices;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var objList = await usersServices.GetList();
            return Ok(objList);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> Post(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var objUser = await usersServices.Insert(users);

            if (!objUser)
            {
                ModelState.AddModelError("", $"An error occurs saving the user {users.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Users users)
        {
            if (await usersServices.Update(users) )
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var isDeleted = await usersServices.Delete(id);

            if (isDeleted) 
            {
                return Ok();
            }
            else
            {
                ModelState.AddModelError("", $"A Error occur Deleting de user with Id =  {id}");
                return StatusCode(404, ModelState);
            }
        }
    }
}
