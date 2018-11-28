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
    public class BookShelvesController : ControllerBase
    {
        private readonly heeyeong_kenny_group_projectContext _context;

        public BookShelvesController(heeyeong_kenny_group_projectContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<Bookshelf>> GetAll()
        {
            return _context.Bookshelf.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetBookShelf")]
        public ActionResult<Bookshelf> GetById(int id)
        {
            var bookshelf = _context.Bookshelf.Find(id);
            if (bookshelf == null)
            {
                return NotFound();
            }
            return bookshelf;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody]Bookshelf bookshelf)
        {
            _context.Bookshelf.Add(bookshelf);
            _context.SaveChanges();

            return CreatedAtRoute("GetBookShelf", new { id = bookshelf.Id }, bookshelf);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bookshelf = _context.Bookshelf.Find(id);
            _context.Bookshelf.Remove(bookshelf);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
