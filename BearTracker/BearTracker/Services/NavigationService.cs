using BearTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BearTracker.Services
{
    public class NavigationService : INavigationService
    {
        private ViewModelBase previousPageViewModel = null;
        public ViewModelBase PreviousPageViewModel { get { return previousPageViewModel; } }

        public Task GoBackAsync()
        {
            if (Application.Current.MainPage is NavigationPage navPage)
                navPage.Navigation.PopAsync();

            return Task.FromResult(true);
        }

        public Task InitializeAsync()
        {
           return NavigateToAsync<ProjectListViewModel>();
        }

        public async Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            await InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public async Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            await InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task RemoveBackStackAsync()
        {
            if (Application.Current.MainPage is NavigationPage navPage)
            {
                IReadOnlyList<Page> backStack = navPage.Navigation.NavigationStack;
                foreach (Page page in backStack)
                    navPage.Navigation.RemovePage(page);
            }

            return Task.FromResult(true);
        }

        public Task RemoveLastFromBackStackAsync()
        {
            if (Application.Current.MainPage is NavigationPage navPage)
            {
                IReadOnlyList<Page> backStack = navPage.Navigation.NavigationStack;
                navPage.Navigation.RemovePage(backStack[backStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType);

            if (Application.Current.MainPage is NavigationPage navPage)
                await navPage.PushAsync(page);
            else
                Application.Current.MainPage = new NavigationPage(page);

            if (page.BindingContext != null)
                await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        private Page CreatePage(Type viewModelType)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
                throw new Exception($"Cannot locate page type for {viewModelType}");

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            string viewName = viewModelType.FullName.Replace("Model", string.Empty);
            string viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            string viewAssemblyName = string.Format("{0}, {1}", viewName, viewModelAssemblyName);

            Type viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }
    }
}
