using MeioAmbiente.Models;
using MeioAmbiente.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeioAmbiente
{
    public partial class App : Application
    {
        public static string DatabaseLaction = string.Empty;

        public static string DatabaseMongo = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginView());
        }
        protected override void OnStart()
        {
            MessagingCenter.Subscribe<User>(this, "SucessoLogin",
               (usuario) =>
               {
                   MainPage = new NavigationPage(new MainPageView());//argumento para MasterDetailView eh o usuario
               });
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
