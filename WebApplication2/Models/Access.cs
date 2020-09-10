using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Access
    {
        public Access()
        {
            Event = new HashSet<Event>();
        }

        public int IdAccess { get; set; }
        public string NameAccess { get; set; }

        public ICollection<Event> Event { get; set; }
    }
}
