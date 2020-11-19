using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDAPI_Main.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDtoFIle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserRepo repo;

        public UsersController(IUserRepo repo)
        {
            this.repo = repo;
        }


        // GET api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {            
            return await repo.getAll();
        }

        // GET api/users/[email]
        [HttpGet("{email}")]
        public async Task<ActionResult<User>> Get(string email)
        {
            User user = await repo.get(email);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // PUT api/users
        [HttpPut]
        public ActionResult<User> Put(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (repo.get(user.Email).Equals(null)) 
            {
                return NotFound();
            }
            repo.update(user);
            return Ok(user);
        }

        // DELETE api/users/[email]
        [HttpDelete("{email}")]
        public async Task<ActionResult<User>> Delete(string email)
        {
            User user = await repo.get(email);
            if (user == null)
            {
                return NotFound();
            }
            repo.delete(email);
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> Post(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            repo.update(user);
            return Ok(user);
        }
    }
}
