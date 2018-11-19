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
        [HttpGet("{id}")]
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
        public IActionResult Create(Shelf shelf)
        {
            _context.Shelf.Add(shelf);
            _context.SaveChanges();

            return CreatedAtRoute("GetShelf", new { id = shelf.Id }, shelf);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Shelf item)
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
            if (shelf == null)
            {
                return NotFound();
            }

            _context.Shelf.Remove(shelf);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
