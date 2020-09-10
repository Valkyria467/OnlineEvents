using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class EventUsers
    {
        public int IdEu { get; set; }
        public int IdUser { get; set; }
        public int IdEvent { get; set; }

        public Event IdEventNavigation { get; set; }
        public User IdUserNavigation { get; set; }
    }
}
