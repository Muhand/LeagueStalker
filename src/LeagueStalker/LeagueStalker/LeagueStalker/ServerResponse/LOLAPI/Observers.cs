using System;
using System.Collections.Generic;
using System.Text;
using LeagueStalker.Models;
namespace LeagueStalker.ServerResponse.LOLAPI
{
    public class Observers
    {
        public string encryptionKey { get; set; }
        public List<Observer> observer { get; set; }
        public Observers()
        {

        }
    }
}
