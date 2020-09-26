using System;
using System.Collections.Generic;
using System.Text;

namespace BearTracker.Models.Pocos
{
    public class TaskPoco
    {
        public Guid TaskID { get; set; }
        public Guid ProjectID { get; set; }

        public string Name { get; set; }
        public string Notes { get; set; }

        public string PriorityNaturalID { get; set; }
        public bool Completed { get; set; }
    }
}
