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
    public class ShelvesController : ControllerBase
    {
        private readonly heeyeong_kenny_group_projectContext _context;

        public ShelvesController(heeyeong_kenny_group_projectContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<Shelf>> GetAll()
        {
            return _context.Shelf.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetShelf")]
        public ActionResult<Shelf> GetById(int id)
        {
            var shelf = _context.Shelf.Find(id);
            if (shelf == null)
            {
                return NotFound();
            }
            return shelf;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody]Shelf shelf)
        {
            _context.Shelf.Add(shelf);
            _context.SaveChanges();

            return CreatedAtRoute("GetShelf", new { id = shelf.Id }, shelf);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}", Name = "GetShelf")]
        public IActionResult Update(int id, [FromBody]Shelf item)
        {
            var shelf = _context.Shelf.Find(id);
            if (shelf == null)
            {
                return NotFound();
            }

            shelf.Name = item.Name;

            _context.Shelf.Update(shelf);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var shelf = _context.Shelf.Find(id);
            var bookshelves = from bs in _context.Bookshelf
                            where bs.ShelfId.Equals(id)
                            select bs;
            if (shelf == null && bookshelves == null)
            {
                return NotFound();
            }

            foreach (Bookshelf bookshelf in bookshelves)
            {
                _context.Bookshelf.Remove(bookshelf);
            }
             
            _context.Shelf.Remove(shelf);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
