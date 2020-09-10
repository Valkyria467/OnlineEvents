using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class User
    {
        public User()
        {
            Event = new HashSet<Event>();
            EventUsers = new HashSet<EventUsers>();
        }

        public int IdUser { get; set; }
        public string NameUser { get; set; }
        public string Surname { get; set; }
        public string LoginUser { get; set; }
        public string PasswordUser { get; set; }
        public int RoleUser { get; set; }

        public RoleUser RoleUserNavigation { get; set; }
        public ICollection<Event> Event { get; set; }
        public ICollection<EventUsers> EventUsers { get; set; }
    }
}
