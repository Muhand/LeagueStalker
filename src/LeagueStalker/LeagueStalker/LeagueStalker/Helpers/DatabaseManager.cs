using System;
using LeagueStalker.Interfaces;
using LeagueStalker.Models;
using System.Threading.Tasks;

namespace LeagueStalker.Helpers
{
    public class DatabaseManager
    {
        #region Global Variables
        //Interface object
        IRestService restService;
        #endregion

        //#region Events
        //event EventHandler<LoginFinishedArgs> LoginFinished;
        //event EventHandler<RegisterFinishedArgs> RegisterFinished;
        //event EventHandler<EmailCheckingFinishedArgs> EmailCheckingFinished;
        //event EventHandler<SummonerNameCheckingFinishedArgs> SummonerNameCheckingFinished;
        //event EventHandler<PasswordResetFinishedArgs> PasswordResetFinished;
        //event EventHandler<UserLoadingFinishedArgs> UserLoadingFinished;
        //#endregion

        #region Constructor(s)
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="service">An interface object</param>
        public DatabaseManager(IRestService service)
        {
            restService = service; //Initialize interface object
        }
        #endregion

        //#region DatabaseManager

        ///// <summary>
        ///// Login asynchronously by calling the RestService implementation and return an Enum as a result
        ///// </summary>
        ///// <param name="user">A user object</param>
        ///// <param name="pw">Password to login</param>
        ///// <returns>Enum.Login</returns>
        //public void Login(string email, string pw)
        //{
        //    var res = (Enums.Login)restService.LoginUserAsync(email, pw);
        //    RaiseAnEvent(LoginFinished, new LoginFinishedArgs(res));
        //}

        ///// <summary>
        ///// Register asynchronously by calling the RestService implementation and return an Enum as a result
        ///// </summary>
        ///// <param name="user">A new user to register</param>
        ///// <returns>Enum.Register</returns>
        //public void Register(NewUser user)
        //{
        //    var res = restService.RegisterUserAsync(user);
        //    RaiseAnEvent(RegisterFinished, new RegisterFinishedArgs(res));
        //}

        //public void CheckEmail(string email)
        //{
        //    var res = restService.CheckEmailAsync(email);
        //    RaiseAnEvent(EmailCheckingFinished, new EmailCheckingFinishedArgs(res));
        //}

        //public void CheckSummonerName(string summonerName)
        //{
        //    var res = restService.CheckSummonerNameAsync(summonerName);
        //    RaiseAnEvent(SummonerNameCheckingFinished, new SummonerNameCheckingFinishedArgs(res));
        //}

        //public void ResetPassword(string email)
        //{
        //    var res = restService.ResetPasswordAsync(email);
        //    RaiseAnEvent(PasswordResetFinished, new PasswordResetFinishedArgs(res));
        //}

        //public void LoadUser(string email)
        //{
        //    var res = restService.LoadUserAsync(email);
        //    RaiseAnEvent(UserLoadingFinished, new UserLoadingFinishedArgs(res));
        //}

        //#endregion

        #region DatabaseManager 2
        public Task<Enums.Login> Login(string email, string pw)
        {
            return restService.LoginUserAsync(email, pw);
        }

        public Task<Enums.Register> Register(NewUser user, SummonerInfo summoner)
        {
            return restService.RegisterUserAsync(user, summoner);
        }

        public Task<Enums.Exist> CheckEmail(string email)
        {
            return restService.CheckEmailAsync(email);
        }
        public Task<Enums.Exist> CheckSummoner(string summoner)
        {
            return restService.CheckSummonerNameAsync(summoner);
        }

        public Task<Enums.PasswordReset> ResetPassword(string email)
        {
            return restService.ResetPasswordAsync(email);
        }

        public Task<Enums.LoadUser> LoadUser(string email)
        {
            return restService.LoadUserAsync(email);
        }

        public Task<Enums.ResendConfirmation> ResendConfirmation(string email)
        {
            return restService.ResendConfirmationAsync(email);
        }

        #endregion

        //#region UtilityMethods
        ///// <summary>
        ///// Raise an event
        ///// </summary>
        ///// <param name="eventHandler">The event you would like to raise</param>
        ///// <param name="args">The event arguments</param>
        //private void RaiseAnEvent(EventHandler<LoginFinishedArgs> eventHandler, LoginFinishedArgs args)
        //{
        //    //If event is not null then raise it
        //    eventHandler?.Invoke(this, args);
        //}

        ///// <summary>
        ///// Raise an event
        ///// </summary>
        ///// <param name="eventHandler">The event you would like to raise</param>
        ///// <param name="args">The event arguments</param>
        //private void RaiseAnEvent(EventHandler<RegisterFinishedArgs> eventHandler, RegisterFinishedArgs args)
        //{
        //    //If event is not null then raise it
        //    eventHandler?.Invoke(this, args);
        //}

        ///// <summary>
        ///// Raise an event
        ///// </summary>
        ///// <param name="eventHandler">The event you would like to raise</param>
        ///// <param name="args">The event arguments</param>
        //private void RaiseAnEvent(EventHandler<EmailCheckingFinishedArgs> eventHandler, EmailCheckingFinishedArgs args)
        //{
        //    //If event is not null then raise it
        //    eventHandler?.Invoke(this, args);
        //}

        ///// <summary>
        ///// Raise an event
        ///// </summary>
        ///// <param name="eventHandler">The event you would like to raise</param>
        ///// <param name="args">The event arguments</param>
        //private void RaiseAnEvent(EventHandler<SummonerNameCheckingFinishedArgs> eventHandler, SummonerNameCheckingFinishedArgs args)
        //{
        //    //If event is not null then raise it
        //    eventHandler?.Invoke(this, args);
        //}


        ///// <summary>
        ///// Raise an event
        ///// </summary>
        ///// <param name="eventHandler">The event you would like to raise</param>
        ///// <param name="args">The event arguments</param>
        //private void RaiseAnEvent(EventHandler<PasswordResetFinishedArgs> eventHandler, PasswordResetFinishedArgs args)
        //{
        //    //If event is not null then raise it
        //    eventHandler?.Invoke(this, args);
        //}


        ///// <summary>
        ///// Raise an event
        ///// </summary>
        ///// <param name="eventHandler">The event you would like to raise</param>
        ///// <param name="args">The event arguments</param>
        //private void RaiseAnEvent(EventHandler<UserLoadingFinishedArgs> eventHandler, UserLoadingFinishedArgs args)
        //{
        //    //If event is not null then raise it
        //    eventHandler?.Invoke(this, args);
        //}
        //#endregion
    }

    //public class LoginFinishedArgs : EventArgs
    //{
    //    public Enums.Login FinishedWithCode { get; set; }

    //    public LoginFinishedArgs(Enums.Login finishedWithCode)
    //    {
    //        this.FinishedWithCode = finishedWithCode;
    //    }
    //}
    //public class RegisterFinishedArgs : EventArgs
    //{
    //    public Enums.Register FinishedWithCode { get; set; }

    //    public RegisterFinishedArgs(Enums.Register finishedWithCode)
    //    {
    //        this.FinishedWithCode = finishedWithCode;
    //    }
    //}
    //public class EmailCheckingFinishedArgs : EventArgs
    //{
    //    public Enums.Exist FinishedWithCode { get; set; }

    //    public EmailCheckingFinishedArgs(Enums.Exist finishedWithCode)
    //    {
    //        this.FinishedWithCode = finishedWithCode;
    //    }
    //}
    //public class SummonerNameCheckingFinishedArgs : EventArgs
    //{
    //    public Enums.Exist FinishedWithCode { get; set; }

    //    public SummonerNameCheckingFinishedArgs(Enums.Exist finishedWithCode)
    //    {
    //        this.FinishedWithCode = finishedWithCode;
    //    }
    //}
    //public class PasswordResetFinishedArgs : EventArgs
    //{
    //    public Enums.PasswordReset FinishedWithCode { get; set; }

    //    public PasswordResetFinishedArgs(Enums.PasswordReset finishedWithCode)
    //    {
    //        this.FinishedWithCode = finishedWithCode;
    //    }
    //}
    //public class UserLoadingFinishedArgs : EventArgs
    //{
    //    public Enums.LoadUser FinishedWithCode { get; set; }

    //    public UserLoadingFinishedArgs(Enums.LoadUser finishedWithCode)
    //    {
    //        this.FinishedWithCode = finishedWithCode;
    //    }
    //}
}
