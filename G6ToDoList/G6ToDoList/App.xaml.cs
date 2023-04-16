using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("MaterialIconsRegular.ttf", Alias ="RegularMaterial")]
[assembly: ExportFont("MaterialIconsTwoTone.ttf", Alias = "TwoToneMaterial")]

namespace G6ToDoList
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
