using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueStalker.ServerResponse
{
    public class ResendConfirmation
    {
        public int error { set; get; }
        public int success { set; get; }
        public string email { set; get; }
        public Enums.ResendConfirmation result { set; get; }
    }
}
