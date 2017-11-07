using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueStalker.ServerResponse.LOLAPI
{
    public class Spell
    {
        public string name { get; set; }
        public string description { get; set; }
        public long id { get; set; }
        public int summonerLevel { get; set; }
        public string key { get; set; }

        public Spell()
        {

        }
    }
}
