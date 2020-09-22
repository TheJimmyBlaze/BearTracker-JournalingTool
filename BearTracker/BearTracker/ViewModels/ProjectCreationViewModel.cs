using BearTracker.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BearTracker.ViewModels
{
    public class ProjectCreationViewModel: ViewModelBase
    {
        private readonly INavigationService navService = DependencyService.Get<INavigationService>();

        public ICommand GoBackCommand => new Command(GoBack);

        private async void GoBack()
        {
            await navService.GoBackAsync();
        }
    }
}
