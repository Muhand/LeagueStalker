using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Windows.Input;
using Xamarin.Forms;
using LeagueStalker.Models;
using System.Net;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;

namespace LeagueStalker.ViewModels.Signup
{
    class ValidatingSummonerNameViewModel : INotifyPropertyChanged
    {
        #region Properties

        private SummonerInfo _summonerInfo;

        public SummonerInfo Summoner
        {
            get { return _summonerInfo; }
            private set
            {
                _summonerInfo = value;
                OnPropertyChanged(nameof(Summoner));
            }
        }

        private bool _thereIsError;

        public bool ThereIsError
        {
            get { return _thereIsError; }
            private set
            {
                _thereIsError = value;
                OnPropertyChanged(nameof(ThereIsError));
            }
        }

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

        private bool _isValidating;

        public bool IsValidating
        {
            get { return _isValidating; }
            set
            {
                _isValidating = value;
                OnPropertyChanged(nameof(IsValidating));
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
        public ValidatingSummonerNameViewModel(string summonerName)
        {
            this.SummonerName = summonerName;
            init();
            //new Thread(async () =>
            //{
                LoadSummonerInfoAsync();
            //}).Start();

        }
        #endregion

        #region Utility Methods

        private void init()
        {
            this.ThereIsError = false;
            this.ErrorMessage = "Validating Summoner name";
            this.IsValidating = true;
        }

        private void LoadSummonerInfoAsync()
        {
            //Application.Current.MainPage.Navigation.PopModalAsync();
            SummonerInfo temp = Globals.GetSummonerInfo(this.SummonerName);

            if (temp.ThereIsAnError)
            {
                this.ThereIsError = true;

                //If this is a protocol error then check hte protocl code and display and appropriate error message
                if (temp.exceptionCode == WebExceptionStatus.ProtocolError)
                {
                    switch (temp.errorCode)
                    {
                        case (HttpStatusCode)400:
                            this.ErrorMessage = "There was a bad request, please contact the developer";
                            break;
                        case (HttpStatusCode)401:
                            this.ErrorMessage = "There was an unauthorized request, please contact the developer";
                            break;
                        case (HttpStatusCode)403:
                            this.ErrorMessage = "There was a forbidden request, please contact the developer";
                            break;
                        case (HttpStatusCode)404:
                            this.ErrorMessage = "Summoner Name not found, Please confirm it's correct. If this issue presists then please contact the developer";
                            break;
                        case (HttpStatusCode)405:
                            this.ErrorMessage = "Method not allowed, please contact the developer";
                            break;
                        case (HttpStatusCode)415:
                            this.ErrorMessage = "Unsupported media type, please contact the developer";
                            break;
                        case (HttpStatusCode)429:
                            this.ErrorMessage = "Limit exceeded, please try again later";
                            break;
                        case (HttpStatusCode)500:
                            this.ErrorMessage = "There was an internal error, please try again later";
                            break;
                        case (HttpStatusCode)502:
                            this.ErrorMessage = "Bad gateway, please contact the developer";
                            break;
                        case (HttpStatusCode)503:
                            this.ErrorMessage = "Service is unavailable at this time, please try again later";
                            break;
                        case (HttpStatusCode)504:
                            this.ErrorMessage = "Gateway timed out, please try again later";
                            break;
                        default:
                            this.ErrorMessage = "Unknown error has occured. Please try again later, if this continues then please contact the developer";
                            break;
                    }
                }
                else
                {
                    //Otherwise just set an unknown error message
                    this.ErrorMessage = "Unknown error has occured. Please try again later, if this continues then please contact the developer";
                }
            }
            else
            {
                //If there was no error then just pop off the validation
                this.ErrorMessage = "Summoner name is validated";
                try
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Dismiss();
                    });
                }
                catch(Exception ex)
                {
                    //Debug.WriteLine(ex.StackTrace);
                    throw new Exception(ex.Message);
                }
                
            }

            this.IsValidating = false;
        }

        async private void Dismiss()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
        #endregion
    }
}
