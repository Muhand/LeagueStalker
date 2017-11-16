using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueStalker.Helpers;
using LeagueStalker.Interfaces.Implementation;
using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using Microsoft.AppCenter.Distribute;

namespace LeagueStalker
{
	public partial class App : Application
	{
        public static DatabaseManager DBManager { get; private set; }
        public App()
        {
            InitializeComponent();

            //AppCenter.Start("ios=05489b0d-2d51-4b0c-8b7b-38fbd42992b9;" + "uwp={Your UWP App secret here};" +
            //       "android={Your Android App secret here}",
            //       typeof(Analytics), typeof(Crashes));

            AppCenter.Start("ios=05489b0d-2d51-4b0c-8b7b-38fbd42992b9;",
                   typeof(Analytics), typeof(Crashes), typeof(Push), typeof(Distribute));

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
