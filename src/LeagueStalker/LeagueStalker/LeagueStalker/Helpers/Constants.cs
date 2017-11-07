namespace LeagueStalker.Helpers
{
    struct Constants
    {
        public const string SERVER_URL = "http://www.api.leaguestalker.muhandjumah.com/api/";

        /*This is the server's URL (Leave it as 10.0.2.2, its the default IP address android uses 
         * to bridge between localhost and emulator. uncomment the above line and comment 
         * this line if the app will run on the actual device.*/
        //public const string SERVER_URL = "http://10.0.2.2/SmartNoteServer/api/";
        //public const string SERVER_URL = "http://192.168.29.1/SmartNoteServer/api/";

        //Extension URL to the login page
        //public const string LOGIN_EXT = "login.php?email={0}&password={1}";
        public const string LOGIN_EXT = "login.php";

        //Extension URL to the register page
        public const string REGISTER_EXT = "register.php";

        public const string CHECK_EMAIL_EXT = "emailExist.php";

        public const string CHECK_summoner_EXT = "summonerExist.php";

        public const string RESET_PASSWORD_EXT = "requestPasswordReset.php";
        public const string LOAD_USER_EXT = "loadUser.php";
        public const string RESENT_CONFIRMATION_EMAIL_EXT = "resendEmailConfirmation.php";
    }
}
