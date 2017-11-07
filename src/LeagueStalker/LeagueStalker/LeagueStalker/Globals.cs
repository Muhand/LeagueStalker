using LeagueStalker.Models;
using LeagueStalker.ServerResponse.LOLAPI;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;

namespace LeagueStalker
{
    public struct CDNExtensions
    {
        public static string Spell = "img/spell";
        public static string ProfileIcon = "img/profileicon";
    }

    public struct APILinks
    {
        public static string LeagueVersionLink = "https://na1.api.riotgames.com/lol/static-data/v3/versions";
        public static string SummonerAPILink = "https://na1.api.riotgames.com/lol/summoner/v3/summoners/by-name";
        public static string CDNLink = "http://ddragon.leagueoflegends.com/cdn";
        public static string ChampionLink = "https://na1.api.riotgames.com/lol/static-data/v3/champions";
        public static string ChampionSplashScreenLink = "http://ddragon.leagueoflegends.com/cdn/img/champion/splash";
        public static string SpellLink = "https://na1.api.riotgames.com/lol/static-data/v3/summoner-spells";
    }

    public static class Globals
    {
        public const string RiotAPIKey = "RGAPI-4ccd82ae-493b-4df5-ba3f-7eff7b020842";

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
            //Construct the link
            //ex: https://na1.api.riotgames.com/lol/static-data/v3/versions?api_key=RGAPI-fc468df1-a885-44b5-90dd-8283b4c6e01f

            string link = String.Format("{0}?api_key={1}", APILinks.LeagueVersionLink, RiotAPIKey);

            //Start downloading the json data
            WebClient w = new WebClient();

            try
            {
                string data = w.DownloadString(link);

                //Construct the data
                Newtonsoft.Json.Linq.JContainer versions = JsonConvert.DeserializeObject< Newtonsoft.Json.Linq.JContainer>(data);

                 //s = (Newtonsoft.Json.Linq.JContainer)versions;
                //s[0].Value<string>;

                return versions.First.ToString();
            }
            catch (Exception)
            {

                return "";
            }
        }

        public static SummonerInfo GetSummonerInfo(string summonerName)
        {
            //Construct a link to get the summoner data
            //EX: https://na1.api.riotgames.com/lol/summoner/v3/summoners/by-name/WarDesigner?api_key=RGAPI-af16708c-73aa-451e-8a3d-78242f0c9949
            string link = String.Format("{0}/{1}?api_key={2}", APILinks.SummonerAPILink,summonerName,RiotAPIKey);

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
            string link = String.Format("{0}/{1}/{2}/{3}.png", APILinks.CDNLink, CurrentLeagueVersion,CDNExtensions.ProfileIcon, iconID);

            return link;

        }

        public static Champion GetChampionByID(long id)
        {
            //EX: https://na1.api.riotgames.com/lol/static-data/v3/champions/19?locale=en_US&api_key=RGAPI-fc468df1-a885-44b5-90dd-8283b4c6e01f

            //0 = link for the champion
            //1 = Id for the champion
            //2 = API key
            string link = String.Format("{0}/{1}?locale=en_US&api_key={2}", APILinks.ChampionLink, id, RiotAPIKey);

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

        public static string GetChampionSplashSCreen(string championName)
        {
            //EX: http://ddragon.leagueoflegends.com/cdn/img/champion/splash/Taric_3.jpg

            //0 = link for the splashscreen
            //1 = champion name
            string link = String.Format("{0}/{1}_3.jpg", APILinks.ChampionSplashScreenLink, championName);

            return link;

        }

        public static string GetChampionSplashSCreen(string championName, long skinId)
        {
            //EX: http://ddragon.leagueoflegends.com/cdn/img/champion/splash/Taric_3.jpg

            //0 = link for the splashscreen
            //1 = champion name
            //2 = skin ID
            string link = String.Format("{0}/{1}_{2}.jpg", APILinks.ChampionSplashScreenLink, championName,skinId);

            return link;
        }

        public static Spell GetSpellByID(int spellID)
        {
            //EX: https://na1.api.riotgames.com/lol/static-data/v3/summoner-spells/11?locale=en_US&api_key=RGAPI-fc468df1-a885-44b5-90dd-8283b4c6e01f

            //0 = SpellID
            //1 = API key
            string link = String.Format("{0}/{1}?locale=en_US&api_key={2}", APILinks.SpellLink, spellID, RiotAPIKey);

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
            string link = String.Format("{0}/{1}/{2}/{3}.png", APILinks.CDNLink, CurrentLeagueVersion, CDNExtensions.Spell, spellName);

            return link;

        }
        #endregion
    }
}
