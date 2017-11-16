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
using System.Diagnostics;

namespace LeagueStalker.CustomControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CurrentMatch : ContentView, INotifyPropertyChanged
    {
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

        #region Constructor(s)
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
                Task.Run(async () => await createViews());
            }

            //foreach (var item in TeamA.Children)
            //{
            //    TapGestureRecognizer tp = new TapGestureRecognizer();
            //    tp.Tapped += (sender, e) =>
            //    {
            //        Debug.WriteLine("Clicked");
            //    };
            //    item.GestureRecognizers.Add(tp);
            //}
            //foreach (var item in TeamB.Children)
            //{
            //    TapGestureRecognizer tp = new TapGestureRecognizer();
            //    tp.Tapped += (sender, e) =>
            //    {
            //        Debug.WriteLine("Clicked");
            //    };
            //    item.GestureRecognizers.Add(tp);
            //}

        }
        #endregion

        private async Task createViews()
        {

            foreach (var participant in CurrentGame.participants)
            {

                //Create a new playerview
                PlayerView v = new PlayerView();
                //v.CurrentParticipant = participant;
                v.SummonerIcon = Globals.GetSummonerIcon(participant.profileIconId);
                v.SummonerName = participant.summonerName;
                v.ChampionName = participant.champion.name;
                v.BackgroundImage = Globals.GetChampionSplashScreen(participant.champion.name);
                v.Spell1Icon = Globals.GetSpellIcon(participant.Spell1.key);
                v.Spell2Icon = Globals.GetSpellIcon(participant.Spell2.key);
                v.Keystone1Image = Globals.GetPerkIcon(participant.perks.perkIds[0]);
                v.Keystone2Image = Globals.GetPerkStyleIcon(participant.perks.perkSubStyle);
               
                //Debug.WriteLine(participant.perks.perkIds[0]);

                //for (int i = 0; i < participant.perks.perkIds.Count; i++)
                //{
                //    Debug.WriteLine("PERK #"+i+": "+ participant.perks.perkIds[i]);
                //}

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

                //Task.Run(async () => {

                //});
                TapGestureRecognizer tp = new TapGestureRecognizer();
                tp.Tapped += (sender, e) =>
                {
                    //Debug.WriteLine("CLICKED: "+participant.summonerName);
                    try
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            //p.Navigation.PushModalAsync(new Views.Signup.Main());
                            //Application.Current.MainPage.Navigation.PushModalAsync(new Views.Signup.Main());
                            Application.Current.MainPage = new Views.Extra.PlayerInfo(participant);
                            //Globals.HomePage.Navigation.PushModalAsync(new Views.Extra.PlayerInfo(participant));
                            //this.Navigation.PushModalAsync(new Views.Extra.PlayerInfo(participant));
                        });
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                };
                v.GestureRecognizers.Add(tp);
            }
        }
    }
}