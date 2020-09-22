using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace BearTracker.ViewModels.Base
{
    public static class ViewModelLocator
    {
        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bind) => (bool)bind.GetValue(AutoWireViewModelProperty);

        public static void SetAutoWireViewModel(BindableObject bind, bool value) => bind.SetValue(AutoWireViewModelProperty, value);

        private static void OnAutoWireViewModelChanged(BindableObject bind, object oldValue, object newValue)
        {
            if (bind is Element view)
            {
                Type viewType = view.GetType();

                string viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
                string viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                string viewModelName = string.Format("{0}Model, {1}", viewName, viewAssemblyName);

                Type viewModelType = Type.GetType(viewModelName);
                if (viewModelType == null)
                    return;

                ViewModelBase viewModel = Activator.CreateInstance(viewModelType) as ViewModelBase;
                view.BindingContext = viewModel;
            }
            return;
        }
    }
}
