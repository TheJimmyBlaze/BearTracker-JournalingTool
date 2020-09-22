using System;
using System.Collections.Generic;
using System.Text;

namespace BearTracker.Models
{
    internal class Task
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

        public bool Completed { get; set; }
        public Priority Priority { get; set; }

        public List<TimeEntry> TimeEntries { get; set; }
    }
}
