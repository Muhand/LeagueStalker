using LeagueStalker.ServerResponse.LOLAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeagueStalker.ViewModels.Dashboard
{
    public class ProcessMatchPreviewViewModel : INotifyPropertyChanged
    {

        #region Properties
        private string _notificationMessage;

        public string NotificationMessage
        {
            get { return _notificationMessage; }
            private set
            {
                _notificationMessage = value;
                OnPropertyChanged(nameof(NotificationMessage));
            }
        }

        private bool _isProcessing;

        public bool IsProcessing
        {
            get { return _isProcessing; }
            set
            {
                _isProcessing = value;
                OnPropertyChanged(nameof(IsProcessing));
            }
        }

        private Match _currentMatch;

        public Match CurrentMatch
        {
            get { return _currentMatch; }
            set
            {
                _currentMatch = value;
                OnPropertyChanged(nameof(CurrentMatch));
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

        private ObservableCollection<string> _listItems;

        public ObservableCollection<string> ListItems
        {
            get { return _listItems; }
            set
            {
                _listItems = value;
                OnPropertyChanged(nameof(ListItems));
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
        public ProcessMatchPreviewViewModel(Match match)
        {
            //First initialize the variables
            init();

            //Set the current match
            this.CurrentMatch = match;

            //Start processing the data on a seperate thread
            Thread t = new Thread(new ThreadStart(StartProcessing));
            t.Start();
        }

        private void init()
        {
            this.NotificationMessage = "";
            this.IsProcessing = false;
            this.CurrentMatch = new Match();
            this.ListItems = new ObservableCollection<string>();
            this.CurrentParticipants = new List<Participant>();
        }
        #endregion

        #region Utility Methods
        private void StartProcessing()
        {
            // Notify the user that we are in process now
            this.NotificationMessage = "Processing...";
            this.IsProcessing = true;

            //Check if this match already exist or no
            if (Globals.VisitedMatches.ContainsKey(this.CurrentMatch.gameId))
            {
                #region Exists
                var e_tempM = Globals.VisitedMatches[this.CurrentMatch.gameId];
                var e_tempP = Globals.VisitedParticipantsPerMatch[e_tempM];

                this.CurrentParticipants = e_tempP;
                #endregion
            }
            else
            {
                //If it doens't exist then process it
                #region Doestnt Exist
                //Initialize a variable which will hold the current match detailed data
                var tempGame = Globals.GetDetailedMatch(this.CurrentMatch.gameId);

                //Else if the game was found
                //Start building the players list
                foreach (var participant in tempGame.participants)
                {
                    //Find the current player to get stats from it
                    Player tempPlayer = tempGame.participantIdentities.Find(x => x.participantId == participant.participantId).player;

                    //Perks placeholder
                    Perk tempPerks = new Perk();

                    //Generate perks
                    tempPerks.perkStyle = participant.stats.perkPrimaryStyle;
                    tempPerks.perkSubStyle = participant.stats.perkSubStyle;
                    tempPerks.perkIds = new List<long>();
                    tempPerks.perkIds.Add(participant.stats.perk0);
                    tempPerks.perkIds.Add(participant.stats.perk1);
                    tempPerks.perkIds.Add(participant.stats.perk2);
                    tempPerks.perkIds.Add(participant.stats.perk3);
                    tempPerks.perkIds.Add(participant.stats.perk4);
                    tempPerks.perkIds.Add(participant.stats.perk5);

                    //Our participant to be added to the currentParticipants list
                    Participant tempPart = new Participant(tempPlayer.summonerId, participant.championId,
                                                            participant.spell1Id, participant.spell2Id,
                                                            tempPlayer.summonerName);

                    //Generate participant
                    tempPart.teamId = participant.teamId;
                    tempPart.profileIconId = tempPlayer.profileIcon;
                    tempPart.bot = false;
                    tempPart.gameCustomizationObjects = null;
                    tempPart.perks = tempPerks;

                    //Add our tempPart to the list
                    this.CurrentParticipants.Add(tempPart);
                }

                //Cache the results
                Globals.VisitedMatches.Add(this.CurrentMatch.gameId, this.CurrentMatch);
                Globals.VisitedParticipantsPerMatch.Add(this.CurrentMatch, this.CurrentParticipants);
                #endregion
            }

            foreach (var item in this.CurrentParticipants)
            {
                ListItems.Add(item.summonerInfo.name);
            }
            EXIT:
            //Finished processing so notify the user
            this.NotificationMessage = "Finished Processing";
            this.IsProcessing = false;
        }
        #endregion
    }
}
