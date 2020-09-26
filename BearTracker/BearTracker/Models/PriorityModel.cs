using BearTracker.Models.Pocos;
using BearTracker.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BearTracker.Models
{
    public class PriorityModel: PriorityPoco
    {
        private readonly IDataAccess dataAccess = DependencyService.Get<IDataAccess>();

        private ColourModel colour;
        public ColourModel Colour
        {
            get
            {
                if (colour == null)
                    colour = dataAccess.GetColour(ColourNaturalID);
                return colour;
            }
        }
    }
}
