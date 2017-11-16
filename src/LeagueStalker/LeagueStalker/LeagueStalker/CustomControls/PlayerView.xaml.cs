using LeagueStalker.Views.Extra;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LeagueStalker.ServerResponse.LOLAPI;

namespace LeagueStalker.CustomControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlayerView : ContentView
	{
        #region Properties
        public static readonly BindableProperty KeystoneImage1Property = BindableProperty.Create(
            propertyName: "Keystone1Image",
            returnType: typeof(string),
            declaringType: typeof(PlayerView),
            defaultValue: "");

        public string Keystone1Image
        {
            get { return (string)GetValue(KeystoneImage1Property); }
            set { SetValue(KeystoneImage1Property, value); }
        }

        public static readonly BindableProperty KeystoneImage2Property = BindableProperty.Create(
            propertyName: "Keystone2Image",
            returnType: typeof(string),
            declaringType: typeof(PlayerView),
            defaultValue: "");

        public string Keystone2Image
        {
            get { return (string)GetValue(KeystoneImage2Property); }
            set { SetValue(KeystoneImage2Property, value); }
        }


        public static readonly BindableProperty SummonerIconProperty = BindableProperty.Create(
            propertyName: "SummonerIcon",
            returnType: typeof(string),
            declaringType: typeof(PlayerView),
            defaultValue: "");

        public string SummonerIcon
        {
            get { return (string)GetValue(SummonerIconProperty); }
            set { SetValue(SummonerIconProperty, value); }
        }

        public static readonly BindableProperty Spell1IconProperty = BindableProperty.Create(
            propertyName: "Spell1Icon",
            returnType: typeof(string),
            declaringType: typeof(PlayerView),
            defaultValue: "");

        public string Spell1Icon
        {
            get { return (string)GetValue(Spell1IconProperty); }
            set { SetValue(Spell1IconProperty, value); }
        }

        public static readonly BindableProperty Spell2IconProperty = BindableProperty.Create(
            propertyName: "Spell2Icon",
            returnType: typeof(string),
            declaringType: typeof(PlayerView),
            defaultValue: "");

        public string Spell2Icon
        {
            get { return (string)GetValue(Spell2IconProperty); }
            set { SetValue(Spell2IconProperty, value); }
        }

        public static readonly BindableProperty BackgroundImageProperty = BindableProperty.Create(
            propertyName: "BackgroundImage",
            returnType: typeof(string),
            declaringType: typeof(PlayerView),
            defaultValue: "");

        public string BackgroundImage
        {
            get { return (string)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }

        public static readonly BindableProperty SummonerNameProperty = BindableProperty.Create(
            propertyName: "SummonerName",
            returnType: typeof(string),
            declaringType: typeof(PlayerView),
            defaultValue: "");

        public string SummonerName
        {
            get { return (string)GetValue(SummonerNameProperty); }
            set { SetValue(SummonerNameProperty, value); }
        }

        public static readonly BindableProperty ChampionNameProperty = BindableProperty.Create(
            propertyName: "ChampionName",
            returnType: typeof(string),
            declaringType: typeof(PlayerView),
            defaultValue: "");

        public string ChampionName
        {
            get { return (string)GetValue(ChampionNameProperty); }
            set { SetValue(ChampionNameProperty, value); }
        }

        //public static readonly BindableProperty CurrentParticipantProperty = BindableProperty.Create(
        //    propertyName: "CurrentParticipant",
        //    returnType: typeof(Participant),
        //    declaringType: typeof(PlayerView),
        //    defaultValue: null);

        //public Participant CurrentParticipant
        //{
        //    get { return (Participant)GetValue(CurrentParticipantProperty); }
        //    set { SetValue(CurrentParticipantProperty, value); }
        //}

        //public INavigation localNavigation { get; set; }

        #endregion

        #region Command
        //public ICommand Clicked
        //{
        //    get
        //    {
        //        return new Command(() =>
        //        {
        //            Debug.WriteLine("CLICKED");
        //            //if (CurrentParticipant != null)
        //            ViewPlayerInfo();
        //        });
        //    }
        //}
        //public ICommand Clicked
        //{
        //    get
        //    {
        //        return new Command(() =>
        //        {
        //            SignUp();
        //            //Application.Current.MainPage.Navigation.PushAsync(new Views.Signup.Main());
        //        });
        //    }
        //}

        #endregion

        #region Constructor(s)
        public PlayerView ()
		{
			InitializeComponent ();
            BindingContext = this;
		}
        #endregion

        #region Utility Methods
        //async private void ViewPlayerInfo()
        //{
        //    //await Application.Current.MainPage.Navigation.PushModalAsync(new Views.Extra.PlayerInfo());
        //    await Application.Current.MainPage.Navigation.PushModalAsync(new Views.Signup.Main());
        //}
        //private void SignUp()
        //{
        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        //        localNavigation.PushModalAsync(new Views.Signup.Main());
        //    });
        //    //await Application.Current.MainPage.Navigation.PushModalAsync(new Views.Signup.Main());
        //    //await localNavigation.PushModalAsync(new Views.Signup.Main());
        //    //await this.Navigation.PushModalAsync(new Views.Signup.Main());
        //}
        #endregion
    }
}