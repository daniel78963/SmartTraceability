using System;
using System.Collections.Generic;

#nullable disable

namespace SmartTraceability.Model.Models
{
    public partial class User
    {
        public User()
        {
            Entries = new HashSet<Entry>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }
    }
}
