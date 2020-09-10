using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class RoleUser
    {
        public RoleUser()
        {
            User = new HashSet<User>();
        }

        public int IdRole { get; set; }
        public string NameRole { get; set; }

        public ICollection<User> User { get; set; }
    }
}
