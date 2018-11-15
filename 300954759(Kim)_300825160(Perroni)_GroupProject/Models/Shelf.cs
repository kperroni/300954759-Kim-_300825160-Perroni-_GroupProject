using System;
using System.Collections.Generic;

namespace _300954759_Kim__300825160_Perroni__GroupProject.Models
{
    public partial class Shelf
    {
        public Shelf()
        {
            Bookshelf = new HashSet<Bookshelf>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<Bookshelf> Bookshelf { get; set; }
    }
}
