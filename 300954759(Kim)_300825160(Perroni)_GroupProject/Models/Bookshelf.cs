using System;
using System.Collections.Generic;

namespace _300954759_Kim__300825160_Perroni__GroupProject.Models
{
    public partial class Bookshelf
    {
        public int Id { get; set; }
        public int ShelfId { get; set; }
        public int BookId { get; set; }

        public Book Book { get; set; }
        public Shelf Shelf { get; set; }
    }
}
