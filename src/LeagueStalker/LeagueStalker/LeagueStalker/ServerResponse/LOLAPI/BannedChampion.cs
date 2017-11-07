using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueStalker.ServerResponse.LOLAPI
{
    public class BannedChampion
    {
        public long championId { get; set; }
        public int teamId { get; set; }
        public int pickTurn { get; set; }

        public BannedChampion()
        {

        }
    }
}
