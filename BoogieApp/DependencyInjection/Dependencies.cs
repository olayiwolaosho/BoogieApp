using Autofac;
using BoogieApp.BoogieFuelme.ViewModels;
using BoogieApp.BoogieKnockKnock.ViewModels;
using BoogieApp.BoogieKnockKnock.ViewModels.Base;
using BoogieApp.BoogieKnockKnock.ViewModels.SharpnadoViewModel;
using BoogieApp.GeneralServices.AuthenticationService;
using BoogieApp.GeneralServices.ItemServices;
using BoogieApp.GeneralServices.Location;
using BoogieApp.GeneralServices.Navigation;
using BoogieApp.GeneralServices.RequestProvider;
using BoogieApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoogieApp.DependencyInjection
{
    public static class Dependencies
    {
        public static IContainer container { get; set; }
        public static void RegisterDependencies()
        {
            var _container = new ContainerBuilder();

            _container.RegisterType<RegistrationDataPageViewModel>();
          //_container.Register<BaseViewModel>();
            _container.RegisterType<BottomtabbedpageViewModel>();
            _container.RegisterType<ProfileViewModel>();
            _container.RegisterType<ViewOrderViewModel>();
            _container.RegisterType<VerificationViewModel>();
            _container.RegisterType<LoginViewModels>();
            _container.RegisterType<BaseViewModel>();
            _container.RegisterType<ShoppingCategoryViewModel>();
            _container.RegisterType<FavouriteShopViewModel>();

            _container.RegisterType<RequestProvider>().As<IRequestProvider>().SingleInstance();
            _container.RegisterType<LocationServices>().As<ILocationServices>().SingleInstance();
            _container.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            _container.RegisterType<AuthService>().As<IAuthenticationService>().SingleInstance();
            _container.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();
            //_container.Register<IDependencyService, Services.Dependency.DependencyService>();
            //_container.Register<ISettingsService, SettingsService>();
            //_container.Register<IFixUriService, FixUriService>();
            //_container.Register<ILocationService, LocationService>();
            //_container.Register<ICatalogService, CatalogMockService>();
            //_container.Register<IBasketService, BasketMockService>();
            //_container.Register<IOrderService, OrderMockService>();
            //_container.Register<IUserService, UserMockService>();
            //_container.Register<ICampaignService, CampaignMockService>();

            container = _container.Build();
        }

        public static object Resolve(Type typeName)
        {
            return container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
