using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _300954759_Kim__300825160_Perroni__GroupProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _300954759_Kim__300825160_Perroni__GroupProject.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        // Context variable to perform read/write operations in the database
        private readonly heeyeong_kenny_group_projectContext _context;

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetCreatedBook")]
        public ActionResult<Book> GetById(long id)
        {
            var book = _context.Book.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create(Book book)
        {
            _context.Book.Add(book);
            _context.SaveChanges();

            return CreatedAtRoute("GetCreatedBook", new { id = book.Id }, book);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
