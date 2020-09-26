using BearTracker.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BearTracker.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private readonly INavigationService navService = DependencyService.Get<INavigationService>();
        private readonly IDataAccess dataAccess = DependencyService.Get<IDataAccess>();

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name = default)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public virtual Task InitializeAsync(object navData) => Task.FromResult(true);
    }
}
