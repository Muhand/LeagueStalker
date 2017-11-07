using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueStalker.Helpers;
using LeagueStalker.Interfaces.Implementation;
using Xamarin.Forms;

namespace LeagueStalker
{
	public partial class App : Application
	{
        public static DatabaseManager DBManager { get; private set; }
        public App()
        {
            InitializeComponent();

            DBManager = new DatabaseManager(new RestService());

            //Get current league version
            Globals.CurrentLeagueVersion = Globals.GetCurrentLeagueVersion();

            //MainPage = new NavigationPage(new LeagueStalker.MainPage());
            MainPage = new LeagueStalker.MainPage();

        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
