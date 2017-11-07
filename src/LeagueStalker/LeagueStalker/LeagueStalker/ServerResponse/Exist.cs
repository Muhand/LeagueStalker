using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueStalker.ServerResponse
{
    class Exist
    {
        public int error { set; get; }
        public int success { set; get; }
        public string email { set; get; }
        public Enums.Exist result { set; get; }
    }
}
