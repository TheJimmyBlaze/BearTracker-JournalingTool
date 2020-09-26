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

        public ICommand ClearSearchTextCommand => new Command(ClearSearchText);

        public ProjectListViewModel()
        {
            Title = TITLE_ALL;
        }

        private void ClearSearchText()
        {
            SearchText = string.Empty;
        }
    }
}
