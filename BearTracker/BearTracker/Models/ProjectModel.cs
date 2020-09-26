using BearTracker.Models.Pocos;
using BearTracker.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BearTracker.Models
{
    public class ProjectModel: ProjectPoco
    {
        private readonly IDataAccess dataAccess = DependencyService.Get<IDataAccess>();

        private IconModel icon;
        public IconModel Icon
        {
            get
            {
                if (icon == null)
                    icon = dataAccess.GetIcon(IconNaturalID);
                return icon;
            }
            set
            {
                icon = value;
                IconNaturalID = icon.IconNaturalID;
            }
        }

        private ColourModel colour;
        public ColourModel Colour
        {
            get
            {
                if (colour == null)
                    colour = dataAccess.GetColour(ColourNaturalID);
                return colour;
            }
            set
            {
                colour = value;
                ColourNaturalID = colour.ColourNaturalID;
            }
        }

        private IEnumerable<TaskModel> tasks;
        public IEnumerable<TaskModel> Tasks
        {
            get
            {
                if (tasks == null)
                    tasks = dataAccess.GetAllTasksForProject(ProjectID);
                return tasks;
            }
        }
    }
}
