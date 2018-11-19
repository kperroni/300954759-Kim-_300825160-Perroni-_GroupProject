using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using _300954759_Kim__300825160_Perroni__GroupProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _300954759_Kim__300825160_Perroni__GroupProject.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly heeyeong_kenny_group_projectContext _context;

        public UsersController(heeyeong_kenny_group_projectContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        //[HttpGet("/api/user.{format}"), FormatFilter]
        //[Route("/api/getusers")]
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _context.User.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            var user = _context.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

    }
}
