using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClimaApp.Paginas;

namespace ClimaApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PaginaClim();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
