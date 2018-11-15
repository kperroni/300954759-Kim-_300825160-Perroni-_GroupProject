using System;
using System.Collections.Generic;

namespace _300954759_Kim__300825160_Perroni__GroupProject.Models
{
    public partial class User
    {
        public User()
        {
            Shelf = new HashSet<Shelf>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public ICollection<Shelf> Shelf { get; set; }
    }
}
