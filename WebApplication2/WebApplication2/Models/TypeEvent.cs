using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class TypeEvent
    {
        public TypeEvent()
        {
            Event = new HashSet<Event>();
        }

        public int IdType { get; set; }
        public string NameType { get; set; }

        public ICollection<Event> Event { get; set; }
    }
}
