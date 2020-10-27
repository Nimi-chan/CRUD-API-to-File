using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUDtoFIle.Models;

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
        public ActionResult<IEnumerable<User>> Get()
        {            
            return repo.getAll();
        }

        // GET api/users/[email]
        [HttpGet("{email}")]
        public ActionResult<User> Get(string email)
        {
            User user = repo.get(email);
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
            repo.update(user.Email, user);
            return Ok(user);
        }

        // DELETE apu/users/[email]
        [HttpDelete("{email}")]
        public ActionResult<User> Delete(string email)
        {
            User user = repo.get(email);
            if (user == null)
            {
                return NotFound();
            }
            repo.delete(email);
            return Ok(user);
        }
    }
}
