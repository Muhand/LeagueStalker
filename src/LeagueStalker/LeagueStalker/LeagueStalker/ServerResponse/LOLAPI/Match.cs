using System;
using System.Collections.Generic;
using System.Text;
using LeagueStalker.Enums;
namespace LeagueStalker.ServerResponse.LOLAPI
{
    public class Match
    {
        public PlatformId platformId { get; set; }
        public long gameId { get; set; }
        public int champion { get; set; }
        public int queue { get; set; }
        public int season { get; set; }
        public long MyProptimestamperty { get; set; }
        public Role role { get; set; }
        public Lane lane { get; set; }
    }
}
