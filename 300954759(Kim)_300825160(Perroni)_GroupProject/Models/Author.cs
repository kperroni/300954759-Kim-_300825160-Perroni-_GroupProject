using System;
using System.Collections.Generic;

namespace _300954759_Kim__300825160_Perroni__GroupProject.Models
{
    public partial class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AreaOfInterest { get; set; }

        public ICollection<Book> Book { get; set; }
    }
}
