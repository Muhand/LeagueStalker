using LeagueStalker.CustomControls;
using LeagueStalker.Enums;
using LeagueStalker.ServerResponse.LOLAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LeagueStalker.ViewModels.Dashboard
{
    public class HistoryViewModel : INotifyPropertyChanged
    {
        #region Properties

        private StackLayout _previousMatchesStackLayout;

        public StackLayout PreviousMatchesStackLayout
        {
            get { return _previousMatchesStackLayout; }
            set
            {
                _previousMatchesStackLayout = value;
                OnPropertyChanged(nameof(PreviousMatchesStackLayout));
            }
        }
        public INavigation Navigation { get; set; }
        #endregion

        #region Commands
        //public ICommand CancelCommand
        //{
        //    get
        //    {
        //        return new Command(() =>
        //        {
        //            Cancel();
        //        });
        //    }
        //}

        #endregion

        #region Interfaces
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion

        #region Constructor(s)
        public HistoryViewModel(ref StackLayout previousMatchesStackLayout, INavigation nav)
        {
            this.Navigation = nav;

            this.PreviousMatchesStackLayout = previousMatchesStackLayout;

            new Thread(delegate ()
            {
                LoadPreviousMatches();
            }).Start();
        }
        #endregion

        #region Utility Methods
        private void addNewChild(View child)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                PreviousMatchesStackLayout.Children.Add(child);
            });
        }

        private void LoadPreviousMatches()
        {
            //Get the most 20 recent matches
            Matches matches = Globals.GetMatches(Globals.CurrentUser.UserInfo.accountId, 0, 20);

            //Loop through each match
            foreach (var match in matches.matches)
            {
                //Create a deatiled match for each match
                DetailedMatch temp = Globals.GetDetailedMatch(match.gameId);

                //Create a variable to hold the participant ID
                long currentParticipantId = -1;
                long currentParticipantTeamId = -1;
                GameStatus currentGameStatus = GameStatus.Unknown;
                ParticipantIdentity currentParticipantIdentity = null;
                DetailedParticipant currentParticipant = null;
                Team currentTeam = null;

                //Find if the participant ID for the current match
                foreach (var participantIdentity in temp.participantIdentities)
                {
                    if (participantIdentity.player.summonerName == Globals.CurrentUser.Summonername)
                    {
                        currentParticipantId = participantIdentity.participantId;
                        currentParticipantIdentity = participantIdentity;
                        break;
                    }
                }

                //Find the player's team
                foreach (var participant in temp.participants)
                {
                    if (participant.participantId == currentParticipantId)
                    {
                        currentParticipantTeamId = participant.teamId;
                        currentParticipant = participant;
                        break;
                    }
                }

                //Find if the player have won or lost the game
                foreach (var team in temp.teams)
                {
                    if (team.teamId == currentParticipantTeamId)
                    {
                        switch (team.win)
                        {
                            case Win.Fail:
                                currentGameStatus = GameStatus.Lost;
                                break;
                            case Win.Win:
                                currentGameStatus = GameStatus.Won;
                                break;
                            default:
                                currentGameStatus = GameStatus.Unknown;
                                break;
                        }
                        currentTeam = team;
                        break;
                    }
                }

                //Get KDA for the player
                double kda;
                var participantStats = temp.participants[Convert.ToInt32(currentParticipantId) - 1].stats;
                kda = (participantStats.kills + participantStats.assists + 0.0) / (participantStats.deaths + 0.0);

                MatchView v = new MatchView();
                v.ChampionsIcon = Globals.GetChampionIcon(match.champion);
                v.ChampionsLevel = participantStats.champLevel;
                v.GameStatus = currentGameStatus;
                v.Kills = participantStats.kills;
                v.Deaths = participantStats.deaths;
                v.Assists = participantStats.assists;
                v.KDA = kda;
                v.Item0Icon = Globals.GetItemIcon(participantStats.item0);
                v.Item1Icon = Globals.GetItemIcon(participantStats.item1);
                v.Item2Icon = Globals.GetItemIcon(participantStats.item2);
                v.Item3Icon = Globals.GetItemIcon(participantStats.item3);
                v.Item4Icon = Globals.GetItemIcon(participantStats.item4);
                v.Item5Icon = Globals.GetItemIcon(participantStats.item5);
                v.Item6Icon = Globals.GetItemIcon(participantStats.item6);
                v.Spell1Icon = Globals.GetSpellIcon(currentParticipant.spell1Id);
                v.Spell2Icon = Globals.GetSpellIcon(currentParticipant.spell2Id);


                //Make it tabable
                TapGestureRecognizer tp = new TapGestureRecognizer();
                tp.Tapped += (sender, e) =>
                {
                    //Debug.WriteLine("CLICKED: "+participant.summonerName);
                    try
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            //this.Navigation.PushAsync(new Views.Extra.Match(match, this.Navigation));
                            this.Navigation.PushAsync(new Views.Dashboard.ProcessMatchPreview(match));
                        });
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                };
                v.GestureRecognizers.Add(tp);
                
                //Add the match to the list
                //PreviousMatchesStackLayout.Children.Add(v);
                addNewChild(v);
            }
        }
        #endregion
    }
}
