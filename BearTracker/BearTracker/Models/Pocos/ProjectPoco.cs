using System;
using System.Collections.Generic;
using System.Text;

namespace BearTracker.Models.Pocos
{
    public class ProjectPoco
    {
        public Guid ProjectID { get; set; }

        public string Name { get; set; }
        public string Notes { get; set; }

        public string IconNaturalID { get; set; }
        public string ColourNaturalID { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public bool Completed { get; set; }
        public TimeSpan TotalTimeEstimate { get; set; }
    }
}
