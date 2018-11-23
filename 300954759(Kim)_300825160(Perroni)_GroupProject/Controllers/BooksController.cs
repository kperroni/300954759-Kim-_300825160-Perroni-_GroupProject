using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using _300954759_Kim__300825160_Perroni__GroupProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _300954759_Kim__300825160_Perroni__GroupProject.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        // Context variable to perform read/write operations in the database
        private readonly heeyeong_kenny_group_projectContext _context;

        public BooksController(heeyeong_kenny_group_projectContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            var books = _context.Book.ToList();

            foreach(Book book in books)
            {
               // book.Author = _context.Author.Find(book.AuthorId);
               // book.Genre = _context.Genre.Find(book.GenreId);
                //
               // book.Author.Book = _context.Book.Where(s => s.AuthorId == book.AuthorId).ToList();
               // book.Genre.Book = _context.Book.Where(s => s.GenreId == book.GenreId).ToList();
            }

            return books;
        }

        // GET api/<controller>/5
        [HttpGet("{id}", Name = "GetCreatedBook")]
        public ActionResult<Book> GetById(int id)
        {
            var book = _context.Book.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            book.Author = _context.Author.Find(book.AuthorId);
            book.Genre = _context.Genre.Find(book.GenreId);

            book.Author.Book = _context.Book.Where(s => s.AuthorId == book.AuthorId).ToList();
            book.Genre.Book = _context.Book.Where(s => s.GenreId == book.GenreId).ToList();
            return book;
        }

        // POST api/<controller>
           [HttpPost]
           public ActionResult<Book> Create(Book book)
           {
            _context.Book.Add(book);
            _context.SaveChanges();
             return CreatedAtRoute("GetCreatedBook", new { id = book.Id }, book);
           }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Book book)
        {
            var updateBook = _context.Book.Find(id);
            if (updateBook == null)
            {
                return NotFound();
            }
            updateBook.Title = book.Title;
            updateBook.PublicationDate = book.PublicationDate;
            updateBook.Publisher = book.Publisher;
            updateBook.NumOfPages = book.NumOfPages;
            updateBook.GenreId = book.GenreId;
            updateBook.AuthorId = book.AuthorId;
            _context.Book.Update(updateBook);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Book.Find(id);

            // check if book is not in a shelf before deleting
            _context.Book.Remove(book);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
