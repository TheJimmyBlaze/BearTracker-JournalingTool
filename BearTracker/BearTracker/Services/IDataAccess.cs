using BearTracker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BearTracker.Services
{
    public interface IDataAccess
    {
        IEnumerable<ProjectModel> GetAllProjects();
        IEnumerable<ProjectModel> GetOpenProjects();
        IEnumerable<ProjectModel> GetClosedProjects();

        IEnumerable<TaskModel> GetAllTasksForProject(Guid projectID);

        IEnumerable<TimeEntryModel> GetAllTimeForTask(Guid taksID);

        IconModel GetIcon(string iconID);
        ColourModel GetColour(string colourID);
        PriorityModel GetPriority(string priorityID);
    }
}
