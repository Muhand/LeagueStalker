using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueStalker.ServerResponse
{
    public class Register
    {
        public int error { set; get; }
        public int success { set; get; }
        public string email { set; get; }
        public Enums.Register result { set; get; }
    }
}
