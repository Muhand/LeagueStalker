using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueStalker.ServerResponse.LOLAPI
{
    public class ParticipantIdentity
    {
        public long participantId { get; set; }
        public Player player { get; set; }
    }
}
