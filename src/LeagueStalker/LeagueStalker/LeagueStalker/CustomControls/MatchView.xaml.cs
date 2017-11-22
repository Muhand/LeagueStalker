using LeagueStalker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeagueStalker.CustomControls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MatchView : ContentView
	{
        #region Properties
        public static readonly BindableProperty ChampionsIconProperty = BindableProperty.Create(
            propertyName: "ChampionsIcon",
            returnType: typeof(string),
            declaringType: typeof(MatchView),
            defaultValue: "");

        public string ChampionsIcon
        {
            get { return (string)GetValue(ChampionsIconProperty); }
            set { SetValue(ChampionsIconProperty, value); }
        }

        public static readonly BindableProperty ChampionsLevelProperty = BindableProperty.Create(
            propertyName: "ChampionsLevel",
            returnType: typeof(int),
            declaringType: typeof(MatchView),
            defaultValue: 0);

        public int ChampionsLevel
        {
            get { return (int)GetValue(ChampionsLevelProperty); }
            set { SetValue(ChampionsLevelProperty, value); }
        }

        public static readonly BindableProperty GameStatusProperty = BindableProperty.Create(
            propertyName: "GameStatus",
            returnType: typeof(GameStatus),
            declaringType: typeof(MatchView),
            defaultValue: GameStatus.Unknown);

        public GameStatus GameStatus
        {
            get { return (GameStatus)GetValue(GameStatusProperty); }
            set
            {
                SetValue(GameStatusProperty, value);
                switch (value)
                {
                    case GameStatus.Won:
                        GameStatusColor = Color.FromHex("#00FF00");
                        break;
                    case GameStatus.Lost:
                        GameStatusColor = Color.FromHex("#FF0000");
                        break;
                    case GameStatus.Unknown:
                    default:
                        GameStatusColor = (Color)Application.Current.Resources["DisabledColor"];
                        break;
                }
            }
        }

        public static readonly BindableProperty GameStatusColorProperty = BindableProperty.Create(
            propertyName: "GameStatusColor",
            returnType: typeof(Color),
            declaringType: typeof(MatchView),
            defaultValue: Color.Default);

        public Color GameStatusColor
        {
            get { return (Color)GetValue(GameStatusColorProperty); }
            set { SetValue(GameStatusColorProperty, value); }
        }

        public static readonly BindableProperty KillsProperty = BindableProperty.Create(
        propertyName: "Kills",
        returnType: typeof(int),
        declaringType: typeof(MatchView),
        defaultValue: 0);

        public int Kills
        {
            get { return (int)GetValue(KillsProperty); }
            set
            {
                SetValue(KillsProperty, value);
                KDAOriginalFormat = string.Format("{0}/{1}/{2}",Kills,Deaths,Assists);
            }
        }

        public static readonly BindableProperty DeathsProperty = BindableProperty.Create(
        propertyName: "Deaths",
        returnType: typeof(int),
        declaringType: typeof(MatchView),
        defaultValue: 0);

        public int Deaths
        {
            get { return (int)GetValue(DeathsProperty); }
            set
            {
                SetValue(DeathsProperty, value);
                KDAOriginalFormat = string.Format("{0}/{1}/{2}", Kills, Deaths, Assists);
            }
        }

        public static readonly BindableProperty AssistsProperty = BindableProperty.Create(
        propertyName: "Assists",
        returnType: typeof(int),
        declaringType: typeof(MatchView),
        defaultValue: 0);

        public int Assists
        {
            get { return (int)GetValue(AssistsProperty); }
            set
            {
                SetValue(AssistsProperty, value);
                KDAOriginalFormat = string.Format("{0}/{1}/{2}", Kills, Deaths, Assists);
            }
        }

        public static readonly BindableProperty KDAOriginalFormatProperty = BindableProperty.Create(
            propertyName: "KDAOriginalFormat",
            returnType: typeof(string),
            declaringType: typeof(MatchView),
            defaultValue: "0/0/0");

        public string KDAOriginalFormat
        {
            get { return (string)GetValue(KDAOriginalFormatProperty); }
            set { SetValue(KDAOriginalFormatProperty, value); }
        }

        public static readonly BindableProperty KDAProperty = BindableProperty.Create(
            propertyName: "KDA",
            returnType: typeof(double),
            declaringType: typeof(MatchView),
            defaultValue: 0.0);

        public double KDA
        {
            get { return (double)GetValue(KDAProperty); }
            set { SetValue(KDAProperty, value); }
        }

        public static readonly BindableProperty Item0IconProperty = BindableProperty.Create(
            propertyName: "Item0Icon",
            returnType: typeof(string),
            declaringType: typeof(MatchView),
            defaultValue: "");

        public string Item0Icon
        {
            get { return (string)GetValue(Item0IconProperty); }
            set { SetValue(Item0IconProperty, value); }
        }

        public static readonly BindableProperty Item1IconProperty = BindableProperty.Create(
            propertyName: "Item1Icon",
            returnType: typeof(string),
            declaringType: typeof(MatchView),
            defaultValue: "");

        public string Item1Icon
        {
            get { return (string)GetValue(Item1IconProperty); }
            set { SetValue(Item1IconProperty, value); }
        }

        public static readonly BindableProperty Item2IconProperty = BindableProperty.Create(
            propertyName: "Item2Icon",
            returnType: typeof(string),
            declaringType: typeof(MatchView),
            defaultValue: "");

        public string Item2Icon
        {
            get { return (string)GetValue(Item2IconProperty); }
            set { SetValue(Item2IconProperty, value); }
        }

        public static readonly BindableProperty Item3IconProperty = BindableProperty.Create(
            propertyName: "Item3Icon",
            returnType: typeof(string),
            declaringType: typeof(MatchView),
            defaultValue: "");

        public string Item3Icon
        {
            get { return (string)GetValue(Item3IconProperty); }
            set { SetValue(Item3IconProperty, value); }
        }

        public static readonly BindableProperty Item4IconProperty = BindableProperty.Create(
            propertyName: "Item4Icon",
            returnType: typeof(string),
            declaringType: typeof(MatchView),
            defaultValue: "");

        public string Item4Icon
        {
            get { return (string)GetValue(Item4IconProperty); }
            set { SetValue(Item4IconProperty, value); }
        }

        public static readonly BindableProperty Item5IconProperty = BindableProperty.Create(
            propertyName: "Item5Icon",
            returnType: typeof(string),
            declaringType: typeof(MatchView),
            defaultValue: "");

        public string Item5Icon
        {
            get { return (string)GetValue(Item5IconProperty); }
            set { SetValue(Item5IconProperty, value); }
        }

        public static readonly BindableProperty Item6IconProperty = BindableProperty.Create(
            propertyName: "Item6Icon",
            returnType: typeof(string),
            declaringType: typeof(MatchView),
            defaultValue: "");

        public string Item6Icon
        {
            get { return (string)GetValue(Item6IconProperty); }
            set { SetValue(Item6IconProperty, value); }
        }

        public static readonly BindableProperty Spell1IconProperty = BindableProperty.Create(
            propertyName: "Spell1Icon",
            returnType: typeof(string),
            declaringType: typeof(MatchView),
            defaultValue: "");

        public string Spell1Icon
        {
            get { return (string)GetValue(Spell1IconProperty); }
            set { SetValue(Spell1IconProperty, value); }
        }

        public static readonly BindableProperty Spell2IconProperty = BindableProperty.Create(
            propertyName: "Spell2Icon",
            returnType: typeof(string),
            declaringType: typeof(MatchView),
            defaultValue: "");

        public string Spell2Icon
        {
            get { return (string)GetValue(Spell2IconProperty); }
            set { SetValue(Spell2IconProperty, value); }
        }

        #endregion

        #region Constructor(s)
        public MatchView ()
		{
			InitializeComponent ();
            BindingContext = this;
        }
        #endregion
    }
}