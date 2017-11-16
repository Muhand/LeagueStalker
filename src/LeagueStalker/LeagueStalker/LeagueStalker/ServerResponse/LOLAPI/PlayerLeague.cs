using System;
using System.Collections.Generic;
using System.Text;
using LeagueStalker.Enums;

namespace LeagueStalker.ServerResponse.LOLAPI
{
    public class PlayerLeague
    {
        public string leagueId { get; set; }
        public string leagueName { get; set; }
        public string tier { get; set; }
        public QueueType queueType { get; set; }
        public string rank { get; set; }
        public string playerOrTeamId { get; set; }
        public string playerOrTeamName { get; set; }
        public int leaguePoints { get; set; }
        public long wins { get; set; }
        public long losses { get; set; }
        public bool veteran { get; set; }
        public bool inactive { get; set; }
        public bool freshBlood { get; set; }
        public bool hotStreak { get; set; }
    }
}
