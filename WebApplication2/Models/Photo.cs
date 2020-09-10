﻿using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Photo
    {
        public Photo()
        {
            Event = new HashSet<Event>();
        }

        public int IdPhoto { get; set; }
        public string NamePhoto { get; set; }
        public string SurnamePhoto { get; set; }

        public ICollection<Event> Event { get; set; }
    }
}
