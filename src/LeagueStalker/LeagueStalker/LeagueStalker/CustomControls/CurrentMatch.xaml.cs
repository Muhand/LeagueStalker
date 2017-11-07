using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LeagueStalker.Models;
using LeagueStalker.ServerResponse.LOLAPI;
using System.ComponentModel;
using System.Threading;

namespace LeagueStalker.CustomControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CurrentMatch : ContentView, INotifyPropertyChanged
    {
        private Random rnd = new Random();
        #region Properties
        public static readonly BindableProperty CurrentGameProperty = BindableProperty.Create(
            propertyName: "CurrentGame",
            returnType: typeof(Game),
            declaringType: typeof(CurrentMatch),
            defaultValue: null);

        public Game CurrentGame
        {
            get { return (Game)GetValue(CurrentGameProperty); }
            set
            {
                SetValue(CurrentGameProperty, value);
                OnPropertyChanged(nameof(CurrentGame));
            }

        }
        #endregion

        #region Interfaces
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion

        public CurrentMatch (Game g)
		{
			InitializeComponent ();

            CurrentGame = g;

            //As long as our current game is not null
            if(CurrentGame != null)
            {
                //new Thread(async () =>
                //{
                //    createViews();
                //}).Start();

                foreach (var participant in CurrentGame.participants)
                {

                    //Create a new playerview
                    PlayerView v = new PlayerView();
                    //v.BackgroundColor = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    v.SummonerIcon = Globals.GetSummonerIcon(participant.profileIconId);
                    v.SummonerName = participant.summonerName;
                    //v.ChampionName = participant.champion.name;
                    //v.ChampionName = "TEST";
                    //v.BackgroundImage = Globals.GetChampionSplashSCreen(participant.champion.name);
                    //v.Spell1Icon = Globals.GetSpellIcon(participant.Spell1.key);
                    //v.Spell2Icon = Globals.GetSpellIcon(participant.Spell2.key);

                    //If the participant belongs to team 100 (first team) then add it to the first group
                    //Otherwise add it to the other group
                    if (participant.teamId == 100)
                    {
                        TeamA.Children.Add(v);
                    }
                    else
                    {
                        TeamB.Children.Add(v);
                    }
                    Thread.Sleep(10000);
                }

            }
		}

        private void createViews()
        {
            foreach (var participant in CurrentGame.participants)
            {

                //Create a new playerview
                PlayerView v = new PlayerView();
                //v.BackgroundColor = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                v.SummonerIcon = Globals.GetSummonerIcon(participant.profileIconId);
                v.SummonerName = participant.summonerName;
                v.ChampionName = participant.champion.name;
                v.BackgroundImage = Globals.GetChampionSplashSCreen(participant.champion.name);
                v.Spell1Icon = Globals.GetSpellIcon(participant.Spell1.key);
                v.Spell2Icon = Globals.GetSpellIcon(participant.Spell2.key);

                //If the participant belongs to team 100 (first team) then add it to the first group
                //Otherwise add it to the other group
                if (participant.teamId == 100)
                {
                    TeamA.Children.Add(v);
                }
                else
                {
                    TeamB.Children.Add(v);
                }
            }
        }
	}
}