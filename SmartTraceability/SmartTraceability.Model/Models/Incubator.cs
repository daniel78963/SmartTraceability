using System;
using System.Collections.Generic;

#nullable disable

namespace SmartTraceability.Model.Models
{
    public partial class Incubator
    {
        public Incubator()
        {
            Entries = new HashSet<Entry>();
        }

        public int IncubatorId { get; set; }
        public string SerialCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string KeyActivation { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }
    }
}
