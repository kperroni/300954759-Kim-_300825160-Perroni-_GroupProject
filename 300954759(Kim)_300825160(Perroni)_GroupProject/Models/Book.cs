using System;
using System.Collections.Generic;

namespace _300954759_Kim__300825160_Perroni__GroupProject.Models
{
    public partial class Book
    {
        public Book()
        {
            Bookshelf = new HashSet<Bookshelf>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Publisher { get; set; }
        public int NumOfPages { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }

        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Bookshelf> Bookshelf { get; set; }
    }
}
