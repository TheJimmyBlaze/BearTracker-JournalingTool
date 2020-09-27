using BearTracker.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BearTracker.ViewModels
{
    public class ProjectListViewModel : ViewModelBase
    {
        private const string TITLE_ALL = "All Projects";
        private const string TITLE_OPEN = "Open Projects";
        private const string TITLE_CLOSED = "Closed Projects";

        public enum Filter
        {
            Open,
            Closed,
            All
        };

        public enum Sort
        { 
            Descending,
            Ascending
        };

        private Filter projectFilter;
        public Filter ProjectFilter
        {
            get { return projectFilter; }
            set
            {
                projectFilter = value;
                OnPropertyChanged(nameof(ProjectFilter));
            }
        }
        public ICommand ToggleFilter => new Command<Filter>(x => SetProjectFilter(x));

        private Sort projectSort;
        public Sort ProjectSort
        {
            get { return projectSort; }
            set
            {
                projectSort = value;
                OnPropertyChanged(nameof(ProjectSort));
            }
        }
        public ICommand ToggleSort => new Command<Sort>(x => ProjectSort = x);

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }
        public ICommand ClearSearchTextCommand => new Command(x => SearchText = string.Empty);

        private bool displayFilters;
        public bool DisplayFilters
        {
            get { return displayFilters; }
            set
            {
                displayFilters = value;
                OnPropertyChanged(nameof(DisplayFilters));
            }
        }
        public ICommand ToggleDisplayFilters => new Command(x => DisplayFilters = !DisplayFilters);

        public ProjectListViewModel()
        {
            Title = TITLE_OPEN;
        }

        private void SetProjectFilter(Filter filter)
        {
            ProjectFilter = filter;

            switch (ProjectFilter)
            {
                case Filter.All:
                    Title = TITLE_ALL;
                    break;
                case Filter.Open:
                    Title = TITLE_OPEN;
                    break;
                case Filter.Closed:
                    Title = TITLE_CLOSED;
                    break;
            }
        }
    }
}
