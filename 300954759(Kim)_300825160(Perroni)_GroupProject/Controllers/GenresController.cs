using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _300954759_Kim__300825160_Perroni__GroupProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _300954759_Kim__300825160_Perroni__GroupProject.Controllers
{
    [Route("api/[controller]")]
    public class GenresController : Controller
    {
        private readonly heeyeong_kenny_group_projectContext _context;

        public GenresController(heeyeong_kenny_group_projectContext context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<Genre>> GetAll()
        {
            var genres = _context.Genre.ToList();

            foreach(Genre genre in genres)
            {
                genre.Book = _context.Book.Where(s => s.GenreId == genre.Id).ToList();
            }
            return genres;
        }

        [HttpGet("{id}", Name = "GetCreatedGenre")]
        public ActionResult<Genre> GetById(int id)
        {
            var genre = _context.Genre.Find(id);
            if (genre == null)
            {
                return NotFound();
            }
            genre.Book = _context.Book.Where(s => s.GenreId == genre.Id).ToList();
            return genre;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody]Genre genre)
        {
            _context.Genre.Add(genre);
            _context.SaveChanges();

            return CreatedAtRoute("GetCreatedGenre", new { id = genre.Id }, genre);
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
