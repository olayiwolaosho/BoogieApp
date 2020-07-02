using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace BoogieApp.BoogieKnockKnock.ViewModels.Base
{
    public static class ViewModelLocator
    {

         static ViewModelLocator()
        {


            // View models - by default, TinyIoC will register concrete classes as multi-instance.
            //_container.Register<ProfileViewModel>();
            //_container.Register<NotificationViewModel>();
            //_container.Register<ProfileViewModel>();
           
        }

        public static readonly BindableProperty AutoWireViewModelProperty =
           BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(AutoWireViewModelProperty, value);
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".View.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
           // var viewModel = _container.Resolve(viewModelType);
           // view.BindingContext = viewModel;
        }

    }
}
