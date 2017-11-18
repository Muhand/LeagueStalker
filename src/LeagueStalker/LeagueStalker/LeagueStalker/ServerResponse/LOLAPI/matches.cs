using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueStalker.ServerResponse.LOLAPI
{
    public class Matches
    {
        public List<Match> matches { get; set; }
        public long startIndex { get; set; }
        public long endIndex { get; set; }
        public long totalGames { get; set; }
    }
}
