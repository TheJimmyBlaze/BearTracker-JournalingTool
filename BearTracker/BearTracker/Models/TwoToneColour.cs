using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BearTracker.Models
{
    internal class TwoToneColour
    {
        public string PrimaryColourHex { get; set; }
        public string SecondaryColourHex { get; set; }

        public Color PrimaryColour { get { return CalculateColour(PrimaryColourHex); } }
        public Color SecondaryColour { get { return CalculateColour(SecondaryColourHex); } }

        private Color CalculateColour(string colourHex)
        {
            if (string.IsNullOrEmpty(colourHex))
                return Color.Transparent;
            return Color.FromHex(colourHex);
        }
    }
}
