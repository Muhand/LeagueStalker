using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Net;
using Newtonsoft.Json;
using LeagueStalker.Models;
using LeagueStalker.ServerResponse.LOLAPI;
using LeagueStalker.CustomControls;

namespace LeagueStalker.ViewModels.Dashboard
{
    class HomeViewModel : INotifyPropertyChanged
    {
        #region Properties
        private bool _emailIsConfirmed;

        public bool EmailIsConfirmed
        {
            get { return _emailIsConfirmed; }
            set
            {
                _emailIsConfirmed = value;
                OnPropertyChanged(nameof(EmailIsConfirmed));
            }
        }

        private string _status;

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        private User _currentUser;

        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        private bool _isPlaying;

        public bool IsPlaying
        {
            get { return _isPlaying; }
            set
            {
                _isPlaying = value;
                OnPropertyChanged(nameof(IsPlaying));
            }
        }

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


        #endregion

        #region Commands

        public ICommand ResendConfirmationCommand
        {
            get
            {
                return new Command(() =>
                {
                    ResendConfirmation();
                });
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
        public HomeViewModel(ref Grid g)
        {
            init(ref g);
        }

        public void init(ref Grid g)
        {
            //If email is not confirmed then show the header
            this.EmailIsConfirmed = !Globals.CurrentUser.Confirmed;

            //Get current player
            this.CurrentUser = Globals.CurrentUser;

            //IsPlaying = true;
            if (!CheckIfPlaying())
            {
                this.Status = "You are not" + Environment.NewLine + "playing any game" + Environment.NewLine + "at this moment";
                //this.Status = "You are not currently playing any game.";
                this.IsPlaying = false;
            }
            else
            {
                //this.Status = "You are currently playing";
                this.IsPlaying = true;
                CurrentMatch matchView = new CurrentMatch(this.CurrentGame);
                g.Children.Add(matchView);
                matchView.IsVisible = IsPlaying;
            }
        }

        #endregion

        #region Utility Methods

        private bool CheckIfPlaying()
        {
            //ex: https://na1.api.riotgames.com/lol/spectator/v3/active-games/by-summoner/53062853?api_key=RGAPI-6b863348-a1e4-4f91-8b44-661c069aba89
            string currentGameUrl = string.Format("{0}/{1}?api_key={2}", "https://na1.api.riotgames.com/lol/spectator/v3/active-games/by-summoner", 
                CurrentUser.UserInfo.id, Globals.RiotAPIKey);
            
            //Create a webclient
            WebClient w = new WebClient();

            try
            {
                string data = w.DownloadString(currentGameUrl);

                //If no error then there is a game, start grabbing the current game information

                this.CurrentGame = JsonConvert.DeserializeObject<Game>(data);
                Globals.CurrentGame = this.CurrentGame;
                return true;
            }
            catch (Exception ex)
            {
                return false;
                //throw;
            }

            
        }
        
        async private void ResendConfirmation()
        {
            switch (await App.DBManager.ResendConfirmation(Globals.CurrentUser.Email))
            {
                case Enums.ResendConfirmation.IncorrectEmail:
                    Debug.WriteLine("Incorrect Email");
                    break;
                case Enums.ResendConfirmation.ErrorUpdatingConfirmationDetails:
                    Debug.WriteLine("ErrorUpdatingConfirmationDetails");
                    break;
                case Enums.ResendConfirmation.ErrorSendingEmail:
                    Debug.WriteLine("ErrorSendingEmail");
                    break;
                case Enums.ResendConfirmation.SuccessfullySentConfirmationEmail:
                    Debug.WriteLine("SuccessfullySentConfirmationEmail");
                    break;
                case Enums.ResendConfirmation.UnknownError:
                    Debug.WriteLine("UnknownError");
                    break;
                default:
                    Debug.WriteLine("default");
                    break;
            }
        }
        #endregion
    }
}
