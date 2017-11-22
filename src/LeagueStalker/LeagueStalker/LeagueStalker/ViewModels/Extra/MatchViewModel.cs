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
using LeagueStalker.CustomControls;

namespace LeagueStalker.ViewModels.Extra
{
    public class MatchViewModel : INotifyPropertyChanged
    {
        #region Properties
        private Game _currentGame;
        public Game CurrentGame
        {
            get { return _currentGame; }
            set
            {
                _currentGame = value;
                OnPropertyChanged(nameof(CurrentGame));
            }
        }
        public StackLayout TeamAStackLayout { get; set; }
        public StackLayout TeamBStackLayout { get; set; }

        public INavigation Navigation { get; set; }

        #endregion

        #region Interfaces
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion

        #region Constructor(s)
        public MatchViewModel(Game game, StackLayout teamAStackLayout, StackLayout teamBStackLayout, INavigation nav)
        {
            this.CurrentGame = game;
            this.TeamAStackLayout = teamAStackLayout;
            this.TeamBStackLayout = teamBStackLayout;
            this.Navigation = nav;

            // As long as our current game is not null
            if (CurrentGame != null)
            {
                new Thread(delegate ()
                {
                    createViews();
                }).Start();
                //Task.Run(async () => await createViews());
            }
        }
        #endregion

        #region Utility Methods

        //private async Task createViews()
        private void createViews()
        {

            foreach (var participant in CurrentGame.participants)
            {

                //Create a new playerview
                PlayerView v = new PlayerView();
                //v.CurrentParticipant = participant;
                v.SummonerIcon = Globals.GetSummonerIcon(participant.profileIconId);
                v.SummonerName = participant.summonerInfo.name;
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
                    this.TeamAStackLayout.Children.Add(v);
                }
                else
                {
                    this.TeamBStackLayout.Children.Add(v);
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
                            //Application.Current.MainPage = new Views.Extra.PlayerInfo(participant);
                            this.Navigation.PushAsync(new Views.Extra.PlayerInfo(participant));
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

        #endregion
    }
}
