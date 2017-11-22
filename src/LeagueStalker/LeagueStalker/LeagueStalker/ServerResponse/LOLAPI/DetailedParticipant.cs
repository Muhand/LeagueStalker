using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueStalker.ServerResponse.LOLAPI
{
    public class DetailedParticipant
    {
        public long participantId { get; set; }
        public long teamId { get; set; }
        public long championId { get; set; }
        public int spell1Id { get; set; }
        public int spell2Id { get; set; }
        public string highestAchievedSeasonTier { get; set; }
        public Stats stats { get; set; }
        public Timeline timeline { get; set; }
    }
}
