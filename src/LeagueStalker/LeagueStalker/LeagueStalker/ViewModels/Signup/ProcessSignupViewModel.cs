using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using LeagueStalker.Models;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;

namespace LeagueStalker.ViewModels.Signup
{
    class ProcessSignupViewModel : INotifyPropertyChanged
    {

        #region Properties

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            private set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
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

        private string _email;

        public string Email
        {
            get { return _email; }
            private set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _summonerName;

        public string SummonerName
        {
            get { return _summonerName; }
            private set
            {
                _summonerName = value;
                OnPropertyChanged(nameof(SummonerName));
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            private set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private bool _signedUpSuccessfully;

        public bool SignedUpSuccessfully
        {
            get { return _signedUpSuccessfully; }
            set
            {
                _signedUpSuccessfully = value;
                OnPropertyChanged(nameof(SignedUpSuccessfully));
            }
        }


        #endregion

        #region Commands

        public ICommand dismissCommand
        {
            get
            {
                return new Command(() =>
                {
                    Dismiss();
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
        public ProcessSignupViewModel(string email, string summonerName, string password)
        {
            this.Email = email;
            this.SummonerName = summonerName;
            this.Password = password;

            init();

            //Start the registeration process
            Debug.WriteLine("Registering is in process: " + Environment.NewLine +
                "Email: " + this.Email + Environment.NewLine +
                "Summoner Name: " + this.SummonerName + Environment.NewLine +
                "Password: " + this.Password + Environment.NewLine);

            new Thread(async () =>
            {
                processSignUp();
            }).Start();

        }
        #endregion

        #region Utility Methods

        private void init()
        {
            this.ErrorMessage = "Processing";
            this.IsProcessing = true;
        }

        async private void Dismiss()
        {
            //if (this.SignedUpSuccessfully)
            //    await Application.Current.MainPage.Navigation.PopToRootAsync();
            //else
                await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        private async void processSignUp()
        {
            //Local variables
            bool error = false;
            List<String> errorList = new List<string>();
            //Check if email, password and summoner name are correct (follow restrictions)

            //Check if email or summoner name are aleady registered 
            switch (await App.DBManager.CheckEmail(this.Email))
            {
                case Enums.Exist.Exists:
                    error = true;
                    errorList.Add("This email already exists.");
                    break;
                case Enums.Exist.DoesntExist:
                    break;
                case Enums.Exist.UnknownError:
                    error = true;
                    errorList.Add("An unknown error has occured while validating email.");
                    break;
                default:
                    error = true;
                    errorList.Add("An unknown error has occured while validating summoner name.");
                    break;
            }

            switch (await App.DBManager.CheckSummoner(this.SummonerName))
            {
                case Enums.Exist.Exists:
                    error = true;
                    errorList.Add("This summoner name is already registered.");
                    break;
                case Enums.Exist.DoesntExist:
                    break;
                case Enums.Exist.UnknownError:
                    error = true;
                    errorList.Add("An unknown error has occured while validating summoner name.");
                    break;
                default:
                    error = true;
                    errorList.Add("An unknown error has occured while validating summoner name.");
                    break;
            }

            //If there was an error then display the list of errors
            if(error)
            {
                this.IsProcessing = false;
                this.SignedUpSuccessfully = false;
                //Clear the error message to start appending the errors to it
                this.ErrorMessage = "The following errors have occured: ";
                for (int i = 0; i < errorList.Count; i++)
                    this.ErrorMessage += String.Format("{0}. {1}\n",i+1,errorList[i]);
            }
            //As long as there were no errors then move on
            else
            {
                //Get the summoner information
                var summoner = Globals.GetSummonerInfo(this.SummonerName);

                //Create a new user
                Models.NewUser newUser = new NewUser();
                newUser.Email = this.Email;
                newUser.SummonerName = this.SummonerName;
                newUser.Password = this.Password;

                //Start inserting
                switch (await App.DBManager.Register(newUser, summoner))
                {
                    case Enums.Register.UserExists:
                        error = true;
                        this.ErrorMessage = "This user already exists, please check email and summonername.";
                        errorList.Add(this.ErrorMessage);
                        break;
                    case Enums.Register.Successful:
                        this.IsProcessing = false;
                        this.SignedUpSuccessfully = true;
                        this.ErrorMessage = "You have successfully registered\nA confirmation email was sent to "+this.Email;
                        break;
                    case Enums.Register.SuccessfulButConfirmationEmailWasNotSent:
                        error = true;
                        this.ErrorMessage = "You have successfully registered\nHowever, there was an issue sending a confirmation email to " + this.Email+"\nPlease contact our support team.";
                        errorList.Add(this.ErrorMessage);
                        break;
                    case Enums.Register.ErrorInsertingSummonerInfo:
                        error = true;
                        this.ErrorMessage = "There was an error inserting your summoner info into our database, please contact our support team including your summoner name.";
                        errorList.Add(this.ErrorMessage);
                        break;
                    case Enums.Register.UnknownError:
                        error = true;
                        errorList.Add("An unknown error has occured while registering, please try again later.\nIf this issue continues then please contact our support team.");
                        break;
                    default:
                        break;
                }

                if(error)
                {
                    this.IsProcessing = false;
                    this.SignedUpSuccessfully = false;
                    //Clear the error message to start appending the errors to it
                    this.ErrorMessage = "The following errors have occured: ";
                    for (int i = 0; i < errorList.Count; i++)
                        this.ErrorMessage += String.Format("{0}. {1}\n", i + 1, errorList[i]);
                }
            }
        }

        #endregion
    }
}
