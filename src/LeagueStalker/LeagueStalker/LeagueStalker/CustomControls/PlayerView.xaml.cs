using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeagueStalker.CustomControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlayerView : ContentView
	{
        #region Properties
        public static readonly BindableProperty KeystoneImageProperty = BindableProperty.Create(
            propertyName: "KeystoneImage",
            returnType: typeof(string),
            declaringType: typeof(PlayerView),
            defaultValue: "");

        public string KeystoneImage
        {
            get { return (string)GetValue(KeystoneImageProperty); }
            set { SetValue(KeystoneImageProperty, value); }
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
        #endregion

        #region Command
        public ICommand Clicked
        {
            get
            {
                return new Command(() =>
                {
                    Debug.WriteLine("CLICKED");
                });
            }
        }
        #endregion

        public PlayerView ()
		{
			InitializeComponent ();
            BindingContext = this;
		}
	}
}