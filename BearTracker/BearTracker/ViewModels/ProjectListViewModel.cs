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
        private readonly INavigationService navService = DependencyService.Get<INavigationService>();

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

        private void ClearSearchText()
        {
            SearchText = string.Empty;
        }
    }
}
