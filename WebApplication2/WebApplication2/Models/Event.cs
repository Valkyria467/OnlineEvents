using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Event
    {
        public Event()
        {
            EventUsers = new HashSet<EventUsers>();
        }

        public int IdEvent { get; set; }
        public string NameEvent { get; set; }
        public int TypeEvent { get; set; }
        public int Amount { get; set; }
        public DateTime DateEvent { get; set; }
        public int Organizer { get; set; }
        public string City { get; set; }
        public string Sreet { get; set; }
        public string House { get; set; }
        public decimal? Cost { get; set; }
        public int Access { get; set; }
        public int? Leader { get; set; }
        public int Place { get; set; }
        public int? Decor { get; set; }

        public Access AccessNavigation { get; set; }
        public Decor DecorNavigation { get; set; }
        public Leader LeaderNavigation { get; set; }
        public User OrganizerNavigation { get; set; }
        public Place PlaceNavigation { get; set; }
        public TypeEvent TypeEventNavigation { get; set; }
        public ICollection<EventUsers> EventUsers { get; set; }
    }
}
