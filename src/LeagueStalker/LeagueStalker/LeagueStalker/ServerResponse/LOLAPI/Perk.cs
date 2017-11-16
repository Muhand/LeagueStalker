using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueStalker.ServerResponse.LOLAPI
{
    public class Perk
    {
        public List<long> perkIds { get; set; }
        public long perkStyle { get; set; }
        public long perkSubStyle { get; set; }
    }
}
