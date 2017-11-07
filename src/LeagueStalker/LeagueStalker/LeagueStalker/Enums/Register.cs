using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueStalker.Enums
{
    public enum Register
    {
        UserExists,
        Successful,
        SuccessfulButConfirmationEmailWasNotSent,
        ErrorInsertingSummonerInfo,
        UnknownError
    }
}
