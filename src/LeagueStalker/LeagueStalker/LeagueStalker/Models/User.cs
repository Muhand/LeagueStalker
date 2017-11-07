using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueStalker.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Summonername { get; set; }
        public bool Confirmed { get; set; }
        public string Lastaccess { get; set; }
        public long SummonerInfo_ID { get; set; }
        private SummonerInfo _userInfo;
        public SummonerInfo UserInfo
        {
            get { return _userInfo; }
            set
            {
                _userInfo = value;

                //After setting the summoner info 
            }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public User()
        {

        }

        public override string ToString()
        {
            return String.Format("ID: {0}\nEmail: {1}\nSummoner Name: {2}\nConfirmed: {3}\nLast access: {4}\nSummoner Info ID: {5}\nUser Info: {6}", 
                ID, Email,Summonername,Confirmed,Lastaccess,SummonerInfo_ID,UserInfo);
        }
    }
}
