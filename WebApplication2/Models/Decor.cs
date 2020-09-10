using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Decor
    {
        public Decor()
        {
            Event = new HashSet<Event>();
        }

        public int IdDecor { get; set; }
        public string NameDecor { get; set; }
        public string SurnameDecor { get; set; }

        public ICollection<Event> Event { get; set; }
    }
}
