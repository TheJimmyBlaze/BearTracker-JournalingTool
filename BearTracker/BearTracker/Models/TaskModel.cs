using BearTracker.Models.Pocos;
using BearTracker.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BearTracker.Models
{
    public class TaskModel: TaskPoco
    {
        private readonly IDataAccess dataAccess = DependencyService.Get<IDataAccess>();

        private PriorityModel priority;
        public PriorityModel Priority
        {
            get
            {
                if (priority == null)
                    priority = dataAccess.GetPriority(PriorityNaturalID);
                return priority;
            }
            set
            {
                priority = value;
                PriorityNaturalID = priority.PriorityNaturalID;
            }
        }

        private IEnumerable<TimeEntryModel> timeEntries;
        public IEnumerable<TimeEntryModel> TimeEntries
        {
            get
            {
                if (timeEntries == null)
                    timeEntries = dataAccess.GetAllTimeForTask(TaskID);
                return timeEntries;
            }
        }
    }
}
