using System.Collections.Generic;
using System.Threading.Tasks;
using LeagueStalker.Enums;
using System.Linq;
using LeagueStalker.Models;

namespace LeagueStalker.ServerResponse.LOLAPI
{
    public class Participant
    {
        public SummonerInfo summonerInfo { get; set; }
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
        public Perk perks { get; set; }
        public Champion champion { get; set; }
        public Spell Spell1 { get; set; }
        public Spell Spell2 { get; set; }
        public List<PlayerLeague> PlayerLeagues { get; set; }
        public Matches matches { get; set; }
        public Dictionary<Role,int> PlayedRoles { get; set; }
        public Dictionary<Lane, int> PlayedLanes { get; set; }
        public Role MostPlayedRole { get; set; }
        public Lane MostPlayedLane { get; set; }
        public double MostPlayedRolePercentage { get; set; }
        public double MostPlayedLanePercentage { get; set; }
        
        public Participant(long summonerId, long championId, int spell1Id, int spell2Id, string summonerName)
        {
            champion = Globals.GetChampionByID(championId);
            Spell1 = Globals.GetSpellByID(spell1Id);
            Spell2 = Globals.GetSpellByID(spell2Id);
            //Get player's league
            PlayerLeagues = Globals.GetPlayersLeagues(summonerId);

            summonerInfo = Globals.GetSummonerInfo(summonerName);
            PlayedRoles = new Dictionary<Role, int>();
            PlayedLanes = new Dictionary<Lane, int>();

            Task getMatches = Task.Run(() =>
            {
                matches = Globals.GetMatches(summonerInfo.accountId);
                PopulateLanesAndRolesDictionaries();
            });
        }

        private void PopulateLanesAndRolesDictionaries()
        {
            foreach (var match in matches.matches)
            {
                AddRoleToDictionary(match.role);
                AddLaneToDictionary(match.lane);
            }

            MostPlayedRole = GetMostPlayedRole();
            MostPlayedLane = GetMostPlayedLane();
        }

        private void AddRoleToDictionary(Role role)
        {
            //Check if the current role exist in dictionary
            if(PlayedRoles.ContainsKey(role))
            {
                //Then only increase it's value
                PlayedRoles[role]++;
            }
            else
            {
                //Otherwise just create a new role and set it to be 1
                PlayedRoles.Add(role, 1);
            }
        }

        private void AddLaneToDictionary(Lane lane)
        {
            //Check if the current lane exist in dictionary
            if (PlayedLanes.ContainsKey(lane))
            {
                //Then only increase it's value
                PlayedLanes[lane]++;
            }
            else
            {
                //Otherwise just create a new lane and set it to be 1
                PlayedLanes.Add(lane, 1);
            }
        }

        private Role GetMostPlayedRole()
        {
            Role res = Role.Unknown;

            if (PlayedRoles.Count >= 0)
            {
                var temp = PlayedRoles.Aggregate((l, r) => l.Value > r.Value ? l : r);
                //res = PlayedRoles.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
                MostPlayedRolePercentage = (temp.Value / (matches.totalGames+0.00))*100.00;
                res = temp.Key;
            }
            return res;
        }

        private Lane GetMostPlayedLane()
        {
            Lane res = Lane.Unknown;

            if (PlayedLanes.Count >= 0)
            {
                var temp = PlayedLanes.Aggregate((l, r) => l.Value > r.Value ? l : r);
                MostPlayedLanePercentage = (temp.Value / (matches.totalGames+0.00)) * 100.00;
                res = temp.Key;
            }

            return res;
        }
    }
}
