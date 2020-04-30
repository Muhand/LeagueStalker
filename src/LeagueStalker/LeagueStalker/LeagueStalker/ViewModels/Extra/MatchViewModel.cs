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

        private List<Participant> _currentParticipants;
        public List<Participant> CurrentParticipants
        {
            get { return _currentParticipants; }
            set
            {
                _currentParticipants = value;
                OnPropertyChanged(nameof(CurrentParticipants));
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
            //this.CurrentGame = game;
            this.CurrentParticipants = game.participants;
            this.TeamAStackLayout = teamAStackLayout;
            this.TeamBStackLayout = teamBStackLayout;
            this.Navigation = nav;

            // As long as our current game is not null
            if (CurrentParticipants != null)
            {
                //new Thread(delegate ()
                //{
                //    createViews();
                //}).Start();
                Task.Run(async () => await createViews());
            }
            //init();
        }

        public MatchViewModel(Match match, StackLayout teamAStackLayout, StackLayout teamBStackLayout, INavigation nav)
        {
            ////this.CurrentGame = game;
            //var temp = Globals.GetDetailedMatch(match.gameId);

            //////Clear the current list
            ////if(this.CurrentParticipants != null && this.CurrentParticipants.Count > 0)
            ////    this.CurrentParticipants.Clear();

            //this.CurrentParticipants = new List<Participant>();

            ////Create the players list
            //foreach (var participant in temp.participants)
            //{
            //    //Find the current player to get stats from it
            //    //Player tempPlayer = temp.participantIdentities.Find(x => participant.participantId).player;
            //    Player tempPlayer = temp.participantIdentities.Find(x => x.participantId == participant.participantId).player;

            //    //Perks placeholder
            //    Perk tempPerks = new Perk();

            //    //Generate perks
            //    tempPerks.perkStyle = participant.stats.perkPrimaryStyle;
            //    tempPerks.perkSubStyle = participant.stats.perkSubStyle;
            //    tempPerks.perkIds = new List<long>();
            //    tempPerks.perkIds.Add(participant.stats.perk0);
            //    tempPerks.perkIds.Add(participant.stats.perk1);
            //    tempPerks.perkIds.Add(participant.stats.perk2);
            //    tempPerks.perkIds.Add(participant.stats.perk3);
            //    tempPerks.perkIds.Add(participant.stats.perk4);
            //    tempPerks.perkIds.Add(participant.stats.perk5);

            //    //Our participant to be added to the currentParticipants list
            //    Participant tempPart = new Participant(tempPlayer.summonerId, participant.championId,
            //                                            participant.spell1Id, participant.spell2Id,
            //                                            tempPlayer.summonerName);

            //    //Generate participant
            //    tempPart.teamId = participant.teamId;
            //    tempPart.profileIconId = tempPlayer.profileIcon;
            //    tempPart.bot = false;
            //    tempPart.gameCustomizationObjects = null;
            //    tempPart.perks = tempPerks;


            //    //Add our tempPart to the list
            //    this.CurrentParticipants.Add(tempPart);
            //}
            
            //this.TeamAStackLayout = teamAStackLayout;
            //this.TeamBStackLayout = teamBStackLayout;
            //this.Navigation = nav;

            //// As long as our current game is not null
            //if (CurrentParticipants != null)
            //{
            //    //new Thread(delegate ()
            //    //{
            //    //    createViews();
            //    //}).Start();
            //    Task.Run(async () => await createViews());
            //}
        }

        #endregion

        #region Utility Methods

        private async Task createViews()
        //private void createViews()
        {

            foreach (var participant in this.CurrentParticipants)
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

                Debug.WriteLine("HERE");

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
