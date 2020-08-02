using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BearTracker.Models
{
    internal class Priority
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        
        public string Image { get; set; }
        public TwoToneColour Colour { get; set; }
    }
}
