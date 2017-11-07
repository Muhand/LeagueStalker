using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;
namespace LeagueStalker.ViewModels
{
    class ProcessLoginViewModel : INotifyPropertyChanged
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

        private bool _loggedInSuccessfully;

        public bool LoggedInSuccessfully
        {
            get { return _loggedInSuccessfully; }
            set
            {
                _loggedInSuccessfully = value;
                OnPropertyChanged(nameof(LoggedInSuccessfully));
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
        public ProcessLoginViewModel(string email, string password)
        {
            this.Email = email;
            this.Password = password;

            init();

            //Start the registeration process
            Debug.WriteLine("Logging is in process: " + Environment.NewLine +
                "Email: " + this.Email + Environment.NewLine +
                "Password: " + this.Password + Environment.NewLine);

            new Thread(async () =>
            {
                processLogin();
            }).Start();

        }
        #endregion

        #region Utility Methods

        private void init()
        {
            this.ErrorMessage = "Logging in";
            this.IsProcessing = true;
        }

        async private void Dismiss()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        private async void processLogin()
        {
            //Local variables
            bool error = false;
            List<String> errorList = new List<string>();

            //Check if passowrd is empty
            if(this.Password == null || this.Password == "")
            {
                this.ErrorMessage = "You can not leave the password field empty.";
                this.IsProcessing = false;
                return;
            }

            //If password field was not empty then proceed with the login
            switch (await App.DBManager.Login(this.Email,this.Password))
            {
                case Enums.Login.Success:
                    this.ErrorMessage = "Loading user data";

                    switch (await App.DBManager.LoadUser(this.Email))
                    {
                        case Enums.LoadUser.UserLoaded:
                            this.LoggedInSuccessfully = true;
                            this.IsProcessing = false;
                            MoveToDashBoard();
                            break;
                        case Enums.LoadUser.UnknownError:
                        default:
                            error = true;
                            errorList.Add("There was an issue loading your data, please try again later");
                            break;
                    }
                    break;
                case Enums.Login.InvalidUsernamePassword:
                    Debug.WriteLine("Invalid username/password");
                    error = true;
                    errorList.Add("Invalid username / password");
                    break;
                case Enums.Login.UnknownError:
                default:
                    Debug.WriteLine("Unknown error");
                    break;
            }

            if(error)
            {
                this.ErrorMessage = "The following errors have occured: ";
                for (int i = 0; i < errorList.Count; i++)
                    this.ErrorMessage += String.Format("{0}. {1}\n", i + 1, errorList[i]);
            }

            this.IsProcessing = false;
        }

        private void MoveToDashBoard()
        {
            Debug.WriteLine("Moved to dashboard");
            try
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage.Navigation.PopModalAsync();
                    //Application.Current.MainPage.Navigation.PushModalAsync(new Views.Dashboard.Main());
                    //Application.Current.MainPage.Navigation.PushAsync(new Views.Dashboard.Main());
                    Application.Current.MainPage = new Views.Dashboard.Main();
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
