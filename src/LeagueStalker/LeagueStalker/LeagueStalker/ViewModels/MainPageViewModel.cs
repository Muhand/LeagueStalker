using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;

namespace LeagueStalker.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
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

        public ICommand signupCommand
        {
            get
            {
                return new Command(() =>
                {
                    SignUp();
                    //Application.Current.MainPage.Navigation.PushAsync(new Views.Signup.Main());
                });
            }
        }

        public ICommand loginCommand
        {
            get
            {
                return new Command(() =>
                {
                    Login();
                    //Application.Current.MainPage.Navigation.PushAsync(new Views.Signup.Main());
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
        public MainPageViewModel()
        {

        }
        #endregion

        #region Utility Methods
        async private void SignUp()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new Views.Signup.Main());
            //await this.Navigation.PushModalAsync(new Views.Signup.Main());
        }
        async private void Login()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new Views.ProcessLogin(this.Email, this.Password));
        }
        #endregion
    }
}
