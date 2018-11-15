using System;
using System.Collections.Generic;

namespace _300954759_Kim__300825160_Perroni__GroupProject.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Book> Book { get; set; }
    }
}
