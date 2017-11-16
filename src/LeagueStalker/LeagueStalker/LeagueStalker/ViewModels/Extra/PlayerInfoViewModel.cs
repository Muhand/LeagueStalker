using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using LeagueStalker.ServerResponse.LOLAPI;
using System;
using System.Diagnostics;

namespace LeagueStalker.ViewModels.Extra
{
    class PlayerInfoViewModel : INotifyPropertyChanged
    {
        #region Properties
        private string _summonerIcon;

        public string SummonerIcon
        {
            get { return _summonerIcon; }
            set
            {
                _summonerIcon = value;
                OnPropertyChanged(nameof(SummonerIcon));
            }
        }

        private string _summonerLevel;

        public string SummonerLevel
        {
            get { return _summonerLevel; }
            set
            {
                _summonerLevel = value;
                OnPropertyChanged(nameof(SummonerLevel));
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

        private string _championName;

        public string ChampionName
        {
            get { return _championName; }
            set
            {
                _championName = value;
                OnPropertyChanged(nameof(ChampionName));
            }
        }

        private string _keystone1Image;

        public string Keystone1Image
        {
            get { return _keystone1Image; }
            set
            {
                _keystone1Image = value;
                OnPropertyChanged(nameof(Keystone1Image));
            }
        }

        private string _keystone2Image;

        public string Keystone2Image
        {
            get { return _keystone2Image; }
            set
            {
                _keystone2Image = value;
                OnPropertyChanged(nameof(Keystone2Image));
            }
        }

        private string _spell1Icon;

        public string Spell1Icon
        {
            get { return _spell1Icon; }
            set
            {
                _spell1Icon = value;
                OnPropertyChanged(nameof(Spell1Icon));
            }
        }

        private string _spell2Icon;

        public string Spell2Icon
        {
            get { return _spell2Icon; }
            set
            {
                _spell2Icon = value;
                OnPropertyChanged(nameof(Spell2Icon));
            }
        }

        private string _tierName;

        public string TierName
        {
            get { return _tierName; }
            set
            {
                _tierName = value;
                OnPropertyChanged(nameof(TierName));
            }
        }

        private string _rankName;

        public string RankName
        {
            get { return _rankName; }
            set
            {
                _rankName = value;
                OnPropertyChanged(nameof(RankName));
            }
        }

        private string _rankIcon;

        public string RankIcon
        {
            get { return _rankIcon; }
            set
            {
                _rankIcon = value;
                OnPropertyChanged(nameof(RankIcon));
            }
        }

        public bool LeagueFound { get; private set; }

        private string _wins;

        public string Wins
        {
            get { return _wins; }
            set
            {
                _wins = value;
                OnPropertyChanged(nameof(Wins));
            }
        }

        private string _loses;

        public string Loses
        {
            get { return _loses; }
            set
            {
                _loses = value;
                OnPropertyChanged(nameof(Loses));
            }
        }

        private double _winsProgress;

        public double WinsProgress
        {
            get { return _winsProgress; }
            set
            {
                _winsProgress = value;
                OnPropertyChanged(nameof(WinsProgress));
            }
        }

        private double _losesProgress;

        public double LosesProgress
        {
            get { return _losesProgress; }
            set
            {
                _losesProgress = value;
                OnPropertyChanged(nameof(LosesProgress));
            }
        }

        #endregion

        #region Commands

        public ICommand CancelCommand
        {
            get
            {
                return new Command(() =>
                {
                    Cancel();
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
        public PlayerInfoViewModel(Participant participant)
        {
            //Get player's info
            this.SummonerIcon = Globals.GetSummonerIcon(participant.profileIconId);
            this.SummonerLevel = Globals.GetSummonerInfo(participant.summonerName).summonerLevel.ToString();
            this.SummonerName = participant.summonerName;
            this.ChampionName = participant.champion.name;
            this.Keystone1Image = Globals.GetPerkIcon(participant.perks.perkIds[0]);
            this.Keystone2Image = Globals.GetPerkStyleIcon(participant.perks.perkSubStyle);
            this.Spell1Icon = Globals.GetSpellIcon(participant.Spell1.key);
            this.Spell2Icon = Globals.GetSpellIcon(participant.Spell2.key);

            //Get player's rank
            foreach (var league in participant.PlayerLeagues)
            {
                LeagueFound = false;
                if (league.queueType == Enums.QueueType.RANKED_SOLO_5x5)
                {
                    //PlayerRank = string.Format("{0}_{1}", league.tier, league.rank);
                    this.TierName = league.tier;
                    this.RankName = league.rank;
                    this.Wins = league.wins.ToString();
                    this.Loses = league.losses.ToString();

                    long totalPlayedGames = league.wins + league.losses;
                    //Calculate wins progress
                    WinsProgress = league.wins / (totalPlayedGames+0.0);

                    //Calculate loses progress
                    LosesProgress = league.losses / (totalPlayedGames+0.0);

                    Debug.WriteLine("WINS: " + WinsProgress);
                    Debug.WriteLine("Loses: " + LosesProgress);


                    LeagueFound = true;
                    break;
                }
            }

            if (LeagueFound)
            {
                this.RankIcon = Globals.GetTierIcon(this.TierName, this.RankName);
                this.RankName = string.Format("{0} {1}", TierName, RankName);
            }
            else
            {
                this.RankIcon = Globals.GetTierIcon("PROVISIONAL", "I");
                this.RankName = "Unranked";
            }
        }
        #endregion

        #region Utility Methods
        async private void Cancel()
        {
            //Application.Current.MainPage = Parent;


            //await Application.Current.MainPage.Navigation.PopAsync();
            //await Application.Current.MainPage.Navigation.PopModalAsync();
        }
        #endregion
    }
}
