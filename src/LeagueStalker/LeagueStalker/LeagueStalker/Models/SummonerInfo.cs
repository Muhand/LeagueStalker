using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LeagueStalker.Models
{
    
    public class SummonerInfo
    {
        public long id;
        public long accountId;
        public string name;
        public int ProfileIconID;
        public long revisionDate;
        public long summonerLevel;
        
        //In case there was an error then data will be copied to the following variables
        public bool ThereIsAnError;
        public WebExceptionStatus exceptionCode;
        public HttpStatusCode errorCode;

        public override string ToString()
        {
            return String.Format("ID: {0}\nAccount ID: {1}\nSummoner Name: {2}\nProfile Icon ID: {3}\nRevision Date: {4}\nSummoner Level: {5}",
                id,accountId,name,ProfileIconID,revisionDate,summonerLevel);
        }
    }
}
