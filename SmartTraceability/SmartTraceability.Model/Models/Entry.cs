using System;
using System.Collections.Generic;

#nullable disable

namespace SmartTraceability.Model.Models
{
    public partial class Entry
    {
        public int EntryId { get; set; }
        public int? IncubatorId { get; set; }
        public int? UserId { get; set; }
        public DateTime Date { get; set; }
        public string DataReaded { get; set; }
        public string SerialCode { get; set; }
        public string State { get; set; }
        public string UserName { get; set; }
        public string Incubator { get; set; }
        public string TimeBegin { get; set; }
        public string TimeEnd { get; set; }
        public bool? Synchronized { get; set; }

        public virtual Incubator IncubatorNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
