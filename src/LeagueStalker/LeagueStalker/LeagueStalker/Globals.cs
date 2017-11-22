using LeagueStalker.Models;
using LeagueStalker.ServerResponse.LOLAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeagueStalker
{
    public struct CDNExtensions
    {
        public struct LOL
        {
            public static string Spell = "img/spell";
            public static string ProfileIcon = "img/profileicon";
            public static string ChampionIcon = "img/champion";
            public static string ItemIcon = "img/item";
        }

        public struct Stalker
        {
            public static string ProfileIcon = "profileicons.php";
            public static string PerkIcon = "perk/perk";
            public static string PerkStyleIcon = "perk/perkStyle";
            public static string TierIcon = "ranked/tier";
            public static string Versions = "versions.php";
        }
    }

    public struct APILinks
    {
        public struct LOL
        {
            public static string LeagueVersionLink = "https://na1.api.riotgames.com/lol/static-data/v3/versions";
            public static string SummonerAPILink = "https://na1.api.riotgames.com/lol/summoner/v3/summoners/by-name";
            public static string CDNLink = "http://ddragon.leagueoflegends.com/cdn";
            public static string ChampionLink = "https://na1.api.riotgames.com/lol/static-data/v3/champions";
            public static string ChampionSplashScreenLink = "http://ddragon.leagueoflegends.com/cdn/img/champion/splash";
            public static string SpellLink = "https://na1.api.riotgames.com/lol/static-data/v3/summoner-spells";
            public static string LeaguesLink = "https://na1.api.riotgames.com/lol/league/v3/positions/by-summoner";
            public static string MatchesLink = "https://na1.api.riotgames.com/lol/match/v3/matchlists/by-account";
            public static string DetailedMatchLink = "https://na1.api.riotgames.com/lol/match/v3/matches";
        }

        public struct Stalker
        {
            public static string Static_Data = "http://api.leaguestalker.muhandjumah.com/api/lolapi/static-data";
            public static string Champion = "http://api.leaguestalker.muhandjumah.com/api/lolapi/static-data/champions.php";
            public static string Spell = "http://api.leaguestalker.muhandjumah.com/api/lolapi/static-data/spells.php";
            public static string CDN = "http://api.leaguestalker.muhandjumah.com/cdn";
        }

    }

    public static class Globals
    {
        public const string RiotAPIKey = "RGAPI-5416ff8b-836c-48c8-a26d-8b5ab23b1423";

        #region Properties
        public static User CurrentUser
        {
            get;
            set;
        }

        public static Game CurrentGame
        {
            get;
            set;
        }

        public static string CurrentLeagueVersion
        {
            get;
            set;
        }
        
        #endregion

        #region Utility Methods

        public static string GetCurrentLeagueVersion()
        {
            #region Through League of Legends API
            ////Construct the link
            ////ex: https://na1.api.riotgames.com/lol/static-data/v3/versions?api_key=RGAPI-fc468df1-a885-44b5-90dd-8283b4c6e01f

            //string link = String.Format("{0}?api_key={1}", APILinks.LOL.LeagueVersionLink, RiotAPIKey);

            ////Start downloading the json data
            //WebClient w = new WebClient();

            //try
            //{
            //    string data = w.DownloadString(link);

            //    //Construct the data
            //    Newtonsoft.Json.Linq.JContainer versions = JsonConvert.DeserializeObject< Newtonsoft.Json.Linq.JContainer>(data);

            //     //s = (Newtonsoft.Json.Linq.JContainer)versions;
            //    //s[0].Value<string>;

            //    return versions.First.ToString();
            //}
            //catch (Exception)
            //{

            //    return "";
            //}
            #endregion

            #region Through my own server
            //Construct the link
            //ex: http://api.leaguestalker.muhandjumah.com/api/lolapi/static-data/versions.php

            string link = String.Format("{0}/{1}", APILinks.Stalker.Static_Data, CDNExtensions.Stalker.Versions);

            //Start downloading the json data
            WebClient w = new WebClient();

            try
            {
                string data = w.DownloadString(link);

                //Construct the data
                JArray versions = JsonConvert.DeserializeObject<JArray>(data);

                return versions.First().ToString();
            }
            catch (Exception)
            {
                return "";
            }
            #endregion
        }

        public static SummonerInfo GetSummonerInfo(string summonerName)
        {
            //Construct a link to get the summoner data
            //EX: https://na1.api.riotgames.com/lol/summoner/v3/summoners/by-name/WarDesigner?api_key=RGAPI-af16708c-73aa-451e-8a3d-78242f0c9949
            string link = String.Format("{0}/{1}?api_key={2}", APILinks.LOL.SummonerAPILink,summonerName,RiotAPIKey);

            //Start downloading the json data
            WebClient w = new WebClient();

            //Try to get the data
            try
            {
                //Download the data
                string data = w.DownloadString(link);

                //Construct a summoner object
                SummonerInfo res = JsonConvert.DeserializeObject<SummonerInfo>(data);

                res.ThereIsAnError = false;

                //Return the result
                return res;
            }
            catch (WebException ex)
            {
                //In case there was an error
                SummonerInfo res = new SummonerInfo();

                //If the reason is a protocol error
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    //Get the response code
                    var resp = (HttpWebResponse)ex.Response;

                    //Assign it to the object
                    res.errorCode = resp.StatusCode;
                }

                //Assign the exception code
                res.exceptionCode = ex.Status;
                res.ThereIsAnError = true;

                return res;
            }
        }

        public static string GetSummonerIcon(long iconID)
        {
            //EX: http://ddragon.leagueoflegends.com/cdn/6.24.1/img/profileicon/588.png

            //0 = link for the profile icon
            //1 = League Version
            //2 = Icon ID
            string link = String.Format("{0}/{1}/{2}/{3}.png", APILinks.LOL.CDNLink, CurrentLeagueVersion,CDNExtensions.LOL.ProfileIcon, iconID);
            return link;

        }

        public static string GetChampionIcon(long champID)
        {
            //Get the champ name
            Champion temp = GetChampionByID(champID);

            //EX: http://ddragon.leagueoflegends.com/cdn/7.23.1/img/champion/Aatrox.png

            //0 = link for the CDN
            //1 = Game version
            //2 = ChampionIcon extension
            string link = String.Format("{0}/{1}/{2}/{3}.png", APILinks.LOL.CDNLink, CurrentLeagueVersion, CDNExtensions.LOL.ChampionIcon,temp.name);

            return link;
        }

        public static Champion GetChampionByID(long id)
        {
            //EX: https://na1.api.riotgames.com/lol/static-data/v3/champions/19?locale=en_US&api_key=RGAPI-fc468df1-a885-44b5-90dd-8283b4c6e01f

            //0 = link for the champion
            //1 = Id for the champion
            //2 = API key
            //string link = String.Format("{0}/{1}?locale=en_US&api_key={2}", APILinks.ChampionLink, id, RiotAPIKey);
            string link = String.Format("{0}?id={1}",APILinks.Stalker.Champion, id);

            //Start downloading the json data
            WebClient w = new WebClient();

            //Try to get the data
            try
            {
                //Download the data
                string data = w.DownloadString(link);

                //Construct a summoner object
                Champion res = JsonConvert.DeserializeObject<Champion>(data);

                return res;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public static string GetChampionSplashScreen(string championName)
        {
            //EX: http://ddragon.leagueoflegends.com/cdn/img/champion/splash/Taric_3.jpg

            //0 = link for the splashscreen
            //1 = champion name
            string link = String.Format("{0}/{1}_3.jpg", APILinks.LOL.ChampionSplashScreenLink, championName);

            return link;

        }

        public static string GetChampionSplashScreen(string championName, long skinId)
        {
            //EX: http://ddragon.leagueoflegends.com/cdn/img/champion/splash/Taric_3.jpg

            //0 = link for the splashscreen
            //1 = champion name
            //2 = skin ID
            string link = String.Format("{0}/{1}_{2}.jpg", APILinks.LOL.ChampionSplashScreenLink, championName,skinId);

            return link;
        }

        public static Spell GetSpellByID(int spellID)
        {
            //EX: https://na1.api.riotgames.com/lol/static-data/v3/summoner-spells/11?locale=en_US&api_key=RGAPI-fc468df1-a885-44b5-90dd-8283b4c6e01f

            //0 = SpellID
            //1 = API key
            //string link = String.Format("{0}/{1}?locale=en_US&api_key={2}", APILinks.SpellLink, spellID, RiotAPIKey);
            string link = String.Format("{0}?id={1}",APILinks.Stalker.Spell,spellID);

            //Start downloading the json data
            WebClient w = new WebClient();

            //Try to get the data
            try
            {
                //Download the data
                string data = w.DownloadString(link);

                //Construct a summoner object
                Spell res = JsonConvert.DeserializeObject<Spell>(data);

                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string GetSpellIcon(string spellName)
        {
            //EX: http://ddragon.leagueoflegends.com/cdn/6.24.1/img/spell/SummonerFlash.png

            //0 = link for the icon
            //1 = current League version
            //2 = Extension
            //3 = IconID
            string link = String.Format("{0}/{1}/{2}/{3}.png", APILinks.LOL.CDNLink, CurrentLeagueVersion, CDNExtensions.LOL.Spell, spellName);

            return link;

        }

        public static string GetSpellIcon(int spellId)
        {
            Spell temp = GetSpellByID(spellId);

            //EX: http://ddragon.leagueoflegends.com/cdn/6.24.1/img/spell/SummonerFlash.png

            //0 = link for the icon
            //1 = current League version
            //2 = Extension
            //3 = IconID
            string link = String.Format("{0}/{1}/{2}/{3}.png", APILinks.LOL.CDNLink, CurrentLeagueVersion, CDNExtensions.LOL.Spell, temp.key);

            return link;

        }

        public static string GetPerkIcon(long perkID)
        {
            //EX: http://api.leaguestalker.muhandjumah.com/cdn/perk/perk/8005.png

            //0 = link for the icon
            //1 = Extension
            //2 = IconID
            string link = String.Format("{0}/{1}/{2}.png", APILinks.Stalker.CDN, CDNExtensions.Stalker.PerkIcon, perkID);

            return link;
        }

        public static string GetPerkStyleIcon(long perkID)
        {
            //EX: http://api.leaguestalker.muhandjumah.com/cdn/perk/perkStyle/8000.png

            //0 = link for the icon
            //1 = Extension
            //2 = IconID
            string link = String.Format("{0}/{1}/{2}.png", APILinks.Stalker.CDN, CDNExtensions.Stalker.PerkStyleIcon, perkID);

            return link;
        }

        public static List<PlayerLeague> GetPlayersLeagues(long summonerId)
        {
            //Construct a link to get the summoner data
            //EX: https://na1.api.riotgames.com/lol/league/v3/positions/by-summoner/59219772?api_key=RGAPI-b953fb0b-b023-40d4-a364-a55775382b76

            //0 = link for the leagues
            //1 = summoner ID
            //2 = API Key
            string link = String.Format("{0}/{1}?api_key={2}", APILinks.LOL.LeaguesLink, summonerId, RiotAPIKey);

            //Start downloading the json data
            WebClient w = new WebClient();

            List<PlayerLeague> res = new List<PlayerLeague>();

            //Try to get the data
            try
            {
                //Download the data
                string data = w.DownloadString(link);

                //Construct a summoner object
                res = JsonConvert.DeserializeObject<List<PlayerLeague>>(data);
            }
            catch (WebException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return res;
        }

        public static string GetTierIcon(string tierName, string rank)
        {
            //EX: http://api.leaguestalker.muhandjumah.com/cdn/ranked/tier/BRONZE_I.png

            //0 = link for the cdn
            //1 = Extension
            //2 = tier
            //3 = rank
            string link = String.Format("{0}/{1}/{2}_{3}.png", APILinks.Stalker.CDN, CDNExtensions.Stalker.TierIcon, tierName,rank);

            return link;
        }

        public static Matches GetMatches(long accountId)
        {
            //EX: https://na1.api.riotgames.com/lol/match/v3/matchlists/by-account/220167353?beginIndex=0&endIndex=100&api_key=

            //0 = link for the matches
            //1 = account ID
            //2 = API Key
            string link = String.Format("{0}/{1}?beginIndex=0&endIndex=100&api_key={2}", APILinks.LOL.MatchesLink, accountId, RiotAPIKey);

            //Start downloading the json data
            WebClient w = new WebClient();

            Matches res = new Matches();

            //Try to get the data
            try
            {
                //Download the data
                string data = w.DownloadString(link);

                //Construct a summoner object
                res = JsonConvert.DeserializeObject<Matches>(data);
            }
            catch (WebException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return res;
        }

        public static Matches GetMatches(long accountId, long beginIndex, long endIndex)
        {
            //EX: https://na1.api.riotgames.com/lol/match/v3/matchlists/by-account/220167353?beginIndex=0&endIndex=100&api_key=

            //0 = link for the matches
            //1 = account ID
            //2 = API Key
            string link = String.Format("{0}/{1}?beginIndex={2}&endIndex={3}&api_key={4}", APILinks.LOL.MatchesLink, accountId,beginIndex,endIndex, RiotAPIKey);

            //Start downloading the json data
            WebClient w = new WebClient();

            Matches res = new Matches();

            //Try to get the data
            try
            {
                //Download the data
                string data = w.DownloadString(link);

                //Construct a summoner object
                res = JsonConvert.DeserializeObject<Matches>(data);
            }
            catch (WebException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return res;
        }

        public static DetailedMatch GetDetailedMatch(long matchId)
        {
            //EX: https://na1.api.riotgames.com/lol/match/v3/matches/2650826704?api_key=

            //0 = link for the match
            //1 = account ID
            //2 = API Key
            string link = String.Format("{0}/{1}?api_key={2}", APILinks.LOL.DetailedMatchLink, matchId, RiotAPIKey);

            //Start downloading the json data
            WebClient w = new WebClient();

            DetailedMatch res = new DetailedMatch();

            //Try to get the data
            try
            {
                //Download the data
                string data = w.DownloadString(link);

                //Construct a summoner object
                res = JsonConvert.DeserializeObject<DetailedMatch>(data);
            }
            catch (WebException ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return res;
        }

        public static string GetItemIcon(long iconId)
        {
            //EX: http://ddragon.leagueoflegends.com/cdn/7.23.1/img/item/3460.png

            //0 = link for the CDN
            //1 = Game version
            //2 = ChampionIcon extension
            string link = String.Format("{0}/{1}/{2}/{3}.png", APILinks.LOL.CDNLink, CurrentLeagueVersion, CDNExtensions.LOL.ItemIcon, iconId);

            return link;
        }
        #endregion
    }
}
