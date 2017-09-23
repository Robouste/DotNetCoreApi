using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Repository;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController: Controller
    {
        public IUserRepository UserRepo { get; set; }

        public UserController(IUserRepository _repo)
        {
            UserRepo = _repo;
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return UserRepo.GetAll();
        }

        [HttpGet("{id}", Name = "GetUsers")]
        public IActionResult GetById(string id)
        {
            var item = UserRepo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            UserRepo.Add(item);
            return CreatedAtRoute("GetUser", new { Controller = "User", id = item.UserName }, item);
        }

        [HttpPut]
        public IActionResult Update(string id, [FromBody] User item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var userObj = UserRepo.Find(id);
            if (userObj == null)
            {
                return NotFound();
            }
            UserRepo.Update(item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            UserRepo.Remove(id);
        }
    }
}
