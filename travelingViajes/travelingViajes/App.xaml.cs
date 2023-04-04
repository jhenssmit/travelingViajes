using System;
using System.IO;
using travelingViajes.Data;
using travelingViajes.Views;
using travelingViajes.Views.Usuario;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travelingViajes
{
    public partial class App : Application
    {
        static SQLiteHelper db;

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());
        }
        public static SQLiteHelper SQLiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Vuelos.db3"));
                }
                return db;
            }
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
