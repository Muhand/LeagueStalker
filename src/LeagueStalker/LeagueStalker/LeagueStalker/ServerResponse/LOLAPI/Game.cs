using System.Collections.Generic;
using Newtonsoft.Json;
using LeagueStalker.Models;
using LeagueStalker.Enums;
namespace LeagueStalker.ServerResponse.LOLAPI
{
    public class Game
    {
        [JsonProperty(PropertyName = "gameId")]
        public long gameId { get; set; }
        public int mapId { get; set; }
        public GameMode gameMode { get; set; }
        public GameType gameType { get; set; }
        public long gameQueueConfigId { get; set; }
        public List<Participant> participants { get; set; }
        public Observers observers { get; set; }
        public string platformId { get; set; }
        public List<BannedChampion> bannedChampions { get; set; }
        public long gameStartTime { get; set; }
        public long gameLength { get; set; }

        public Game()
        {

        }
    }
}
