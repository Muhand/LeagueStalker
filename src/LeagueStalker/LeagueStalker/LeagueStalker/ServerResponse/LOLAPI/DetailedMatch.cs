using System;
using LeagueStalker.Enums;
using System.Collections.Generic;

namespace LeagueStalker.ServerResponse.LOLAPI
{
    public class DetailedMatch
    {
        public long gameId { get; set; }
        public string platformId { get; set; }
        public long gameCreation { get; set; }
        public long gameDuration { get; set; }
        public long queueId { get; set; }
        public long mapId { get; set; }
        public long seasonId { get; set; }
        public string gameVersion { get; set; }
        public GameMode gameMode { get; set; }
        public GameType gameType { get; set; }
        public List<Team> teams { get; set; }
        public List<DetailedParticipant> participants { get; set; }
        public List<ParticipantIdentity> participantIdentities { get; set; }
    }
}
