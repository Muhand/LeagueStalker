using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Diagnostics;

namespace LeagueStalker.ViewModels.Signup
{
    class MainViewModel : INotifyPropertyChanged
    {
        #region Properties
        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _summonerName;

        public string SummonerName
        {
            get { return _summonerName; }
            set
            {
                _summonerName = value;
                OnPropertyChanged(nameof(SummonerName));
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        #endregion

        #region Commands
        public ICommand alreadyHaveAnAccountCommand
        {
            get
            {
                return new Command(() =>
                {
                    AlreadyHaveAnAccountCommand();
                });
            }
        }

        public ICommand signupCommand
        {
            get
            {
                return new Command(() =>
                {
                    Signup();
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
        public MainViewModel()
        {
            //this.Email = "muhandjumah@gmail.com";
            //this.SummonerName = "WarDesigne";
            //this.Password = "Tiesto223";
        }
        #endregion

        #region Utility Methods
        async private void AlreadyHaveAnAccountCommand()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        async private void Signup()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new Views.Signup.ProcessSignup(this.Email, this.SummonerName, this.Password));
        }
        #endregion
    }
}
