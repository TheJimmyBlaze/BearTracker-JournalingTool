using System;
using System.Collections.Generic;
using System.Text;

namespace BearTracker.Models.Pocos
{
    public class TimeEntryPoco
    {
        public Guid ID { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? StartDate { get; set; } // Generally this will be null except when a user sets a start date manually.

        public TimeSpan TimeSpent { get; set; }
    }
}
