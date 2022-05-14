using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SrezApp.DataBase;
using System.IO;

namespace SrezApp
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "Project.db";
        internal static Storage db;
        internal static Storage Db
        {
            get
            {
                if (db == null)
                {
                    db = new Storage(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Pages.AuthPage());
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
