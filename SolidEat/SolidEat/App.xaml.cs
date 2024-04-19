using SolidEat.Repositories;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("KoHo-Regular.ttf", Alias = "KoHo")]

namespace SolidEat
{
    public partial class App : Application
    {

        public static UserRepository UserRepository { get; private set; }

        public App()
        {
            InitializeComponent();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "SolidEat.db3");
            UserRepository = new UserRepository(dbPath);

            if (!Application.Current.Properties.ContainsKey("IsRegistered"))
            {
                MainPage = new NavigationPage(new SignUpPage());
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
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
