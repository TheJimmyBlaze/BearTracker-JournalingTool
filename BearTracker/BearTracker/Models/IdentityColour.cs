using System;
using System.Collections.Generic;
using System.Text;

namespace BearTracker.Models
{
    internal class IdentityColour
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public TwoToneColour Colour { get; set; }
    }
}
