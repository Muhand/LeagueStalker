using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueStalker.ServerResponse
{
    public class LoadUser
    {
        public bool IsError { get; set; }
        public int ID { get; set; }
        public string Summonername { get; set; }
        public string Email { get; set; }
        public bool Confirmed { get; set; }
        public string Lastaccess { get; set; }
        public int SummonerInfo_ID { get; set; }
    }
}
