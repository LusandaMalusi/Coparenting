using Prism;
using Prism.Ioc;
using EqualRights.ViewModels;
using EqualRights.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EqualRights.Service.Interface;
using EqualRights.Service;
using System;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EqualRights
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        static CoparentingDatabase database;
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("MasterD/NavigationPage/MainPage");
        }

       

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IData, CoparentingDatabase>();
            containerRegistry.RegisterSingleton<IMenuService, MenuService>();
          

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<CreateAccount, CreateAccountViewModel>();
            containerRegistry.RegisterForNavigation<DetailsPage, DetailsPageViewModel>();
            containerRegistry.RegisterForNavigation<MasterD, MasterDViewModel>();
            containerRegistry.RegisterForNavigation<AboutApp, AboutAppViewModel>();
            containerRegistry.RegisterForNavigation<GalleryPage, GalleryPageViewModel>();
        }
    }
}
