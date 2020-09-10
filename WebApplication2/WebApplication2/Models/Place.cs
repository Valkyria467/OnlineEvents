using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Place
    {
        public Place()
        {
            Event = new HashSet<Event>();
        }

        public int IdPlace { get; set; }
        public string NamePlace { get; set; }

        public ICollection<Event> Event { get; set; }
    }
}
