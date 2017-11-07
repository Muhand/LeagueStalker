using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueStalker.ServerResponse
{
    public class PasswordReset
    {
        public int error { get; set; }
        public string email { get; set; }
        public Enums.PasswordReset errorCode { get; set; }
    }
}
