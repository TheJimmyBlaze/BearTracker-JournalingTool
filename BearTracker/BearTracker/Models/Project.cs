using System;
using System.Collections.Generic;
using System.Text;

namespace BearTracker.Models
{
    internal class Project
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

        public IdentityIcon Icon { get; set; }
        public IdentityColour Colour { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        
        public TimeSpan Estimate { get; set; }

        public List<Task> Tasks { get; set; }
    }
}
