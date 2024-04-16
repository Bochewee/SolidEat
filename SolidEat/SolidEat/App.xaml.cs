using SolidEat.Repositories;
using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("KoHo-Regular.ttf", Alias = "KoHo")]

namespace SolidEat
{
    public partial class App : Application
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "database.db3");

        public static UserRepository UserRepository { get; private set; }

        public App()
        {
            InitializeComponent();

            UserRepository = new UserRepository(dbPath);

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            Debug.WriteLine("OnStart");
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("OnSleep");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("OnResume");
        }
    }
}
