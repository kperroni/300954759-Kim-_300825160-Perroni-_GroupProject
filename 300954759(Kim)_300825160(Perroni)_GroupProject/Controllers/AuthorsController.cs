﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _300954759_Kim__300825160_Perroni__GroupProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _300954759_Kim__300825160_Perroni__GroupProject.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly heeyeong_kenny_group_projectContext _context;

        public AuthorsController(heeyeong_kenny_group_projectContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<Author>> GetAll()
        {
            return _context.Author.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetCreatedAuthor")]
        public ActionResult<Author> GetById(long id)
        {
            var author = _context.Author.Find(id);
            if (author == null)
            {
                return NotFound();
            }
            return author;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create(Author author)
        {
            _context.Author.Add(author);
            _context.SaveChanges();

            return CreatedAtRoute("GetCreatedAuthor", new { id = author.Id }, author);
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
