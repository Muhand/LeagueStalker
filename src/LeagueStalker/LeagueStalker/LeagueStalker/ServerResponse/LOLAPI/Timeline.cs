using LeagueStalker.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueStalker.ServerResponse.LOLAPI
{
    public class Timeline
    {
        public long participantId { get; set; }
        public Dictionary<string,long> creepsPerMinDeltas { get; set; }
        public Dictionary<string,long> xpPerMinDeltas { get; set; }
        public Dictionary<string,long> goldPerMinDeltas { get; set; }
        public Dictionary<string,long> damageTakenPerMinDeltas { get; set; }
        public Role role { get; set; }
        public Lane lane { get; set; }
    }
}
