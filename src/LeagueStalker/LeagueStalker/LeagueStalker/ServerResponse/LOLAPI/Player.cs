using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueStalker.ServerResponse.LOLAPI
{
    public class Player
    {
        public string platformId { get; set; }
        public long accountId { get; set; }
        public string summonerName { get; set; }
        public long summonerId { get; set; }
        public string currentPlatformId { get; set; }
        public long currentAccountId { get; set; }
        public string matchHistoryUri { get; set; }
        public long profileIcon { get; set; }
    }   
}
