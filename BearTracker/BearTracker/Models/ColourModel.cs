using BearTracker.Models.Pocos;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BearTracker.Models
{
    public class ColourModel: ColourPoco
    {
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
