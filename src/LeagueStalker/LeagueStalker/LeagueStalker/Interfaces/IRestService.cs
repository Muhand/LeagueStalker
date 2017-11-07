using LeagueStalker.Models;
using System;
using System.Threading.Tasks;

namespace LeagueStalker.Interfaces
{
    public interface IRestService
    {
        Task<Enums.Login> LoginUserAsync(string email, string pw);
        Task<Enums.Register> RegisterUserAsync(Models.NewUser user, SummonerInfo summoner);
        Task<Enums.Exist> CheckEmailAsync(string email);
        Task<Enums.Exist> CheckSummonerNameAsync(string summonerName);
        Task<Enums.PasswordReset> ResetPasswordAsync(string email);
        Task<Enums.LoadUser> LoadUserAsync(string email);
        Task<Enums.ResendConfirmation> ResendConfirmationAsync(string email);
    }
}
