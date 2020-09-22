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

        private int randomNumber;
        public int RandomNumber
        {
            get
            {
                if (randomNumber == 0)
                    randomNumber = new Random().Next(1, 100);
                return randomNumber;
            }
        }

        public ICommand CreateNewProjectCommand => new Command(CreateNewProject);
        public ICommand ResetRandomNumberCommand => new Command(ResetRandomNumber);

        private async void CreateNewProject()
        {
            await navService.NavigateToAsync<ProjectCreationViewModel>();
        }

        private void ResetRandomNumber()
        {
            randomNumber = 0;
            OnPropertyChanged(nameof(RandomNumber));
        }
    }
}
