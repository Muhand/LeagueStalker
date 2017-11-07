using System;
using System.Collections.Generic;
using System.Text;
using LeagueStalker.Models;
namespace LeagueStalker.ServerResponse.LOLAPI
{
    public class Participant
    {
        public long teamId { get; set; }
        public int spell1Id { get; set; }
        public int spell2Id { get; set; }
        public long championId { get; set; }
        public long profileIconId { get; set; }
        public string summonerName { get; set; }
        public bool bot { get; set; }
        public long summonerId { get; set; }
        public List<Rune> runes { get; set; }
        public List<Mastery> masteries { get; set; }
        public List<object> gameCustomizationObjects { get; set; }
        public Champion champion { get; set; }
        public Spell Spell1 { get; set; }
        public Spell Spell2 { get; set; }


        public Participant(long championId, int spell1Id, int spell2Id)
        {
            champion = Globals.GetChampionByID(championId);
            //Spell1 = Globals.GetSpellByID(spell1Id);
            //Spell2 = Globals.GetSpellByID(spell2Id);
        }
    }
}
