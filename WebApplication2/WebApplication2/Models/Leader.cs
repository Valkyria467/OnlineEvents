using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Leader
    {
        public Leader()
        {
            Event = new HashSet<Event>();
        }

        public int IdLeader { get; set; }
        public string NameLeader { get; set; }
        public string SurnameLeader { get; set; }

        public ICollection<Event> Event { get; set; }
    }
}
