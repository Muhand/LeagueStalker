using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using LeagueStalker.Models;
using System.Threading.Tasks;
using LeagueStalker.Enums;
using LeagueStalker.Helpers;
using Newtonsoft.Json;
using System.Diagnostics;
namespace LeagueStalker.Interfaces.Implementation
{
    class RestService : IRestService
    {
        //Needed to connect to the server
        HttpClient client;

        #region Constructor(s)
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RestService()
        {
            var authData = string.Format("{0}:{1}", "", "");                                            //Server Authentication
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));             //Setup authentication

            client = new HttpClient();                                                                  //Initialize new object of the client
            client.MaxResponseContentBufferSize = 256000;                                               //Max a buffer
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue); //Authentication
        }
        #endregion

        #region Interface Implementation
        public async Task<Exist> CheckEmailAsync(string email)
        {
            ServerResponse.Exist temp = new ServerResponse.Exist();
            Enums.Exist res = Exist.UnknownError;

            var uri = new Uri(string.Format(Constants.SERVER_URL + Constants.CHECK_EMAIL_EXT));

            try
            {
                var httpContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", email)
                });
                var response = await client.PostAsync(uri, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    temp = JsonConvert.DeserializeObject<ServerResponse.Exist>(content);
                    res = temp.result; // Look at Enum.Register for result values
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR {ex.Message}");
            }

            return res;
        }

        public async Task<Exist> CheckSummonerNameAsync(string summonerName)
        {
            ServerResponse.Exist temp = new ServerResponse.Exist();
            Enums.Exist res = Exist.UnknownError;

            var uri = new Uri(string.Format(Constants.SERVER_URL + Constants.CHECK_summoner_EXT));

            try
            {
                var httpContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("summonername", summonerName)
                });
                var response = await client.PostAsync(uri, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    temp = JsonConvert.DeserializeObject<ServerResponse.Exist>(content);
                    res = temp.result; // Look at Enum.Register for result values
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR {ex.Message}");
            }

            return res;
        }

        public async Task<LoadUser> LoadUserAsync(string email)
        {
            ServerResponse.LoadUser temp = new ServerResponse.LoadUser();
            Enums.LoadUser res = LoadUser.UnknownError;

            var uri = new Uri(string.Format(Constants.SERVER_URL + Constants.LOAD_USER_EXT));

            try
            {
                var httpContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", email)
                });
                var response = await client.PostAsync(uri, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    temp = JsonConvert.DeserializeObject<ServerResponse.LoadUser>(content);

                    if (temp.IsError)
                        return Enums.LoadUser.UnknownError;

                    res = Enums.LoadUser.UserLoaded;
                    User loadedUser = new User();

                    loadedUser.ID = temp.ID;
                    loadedUser.Email = temp.Email;
                    loadedUser.Summonername = temp.Summonername;
                    loadedUser.Confirmed = temp.Confirmed;
                    loadedUser.Lastaccess = temp.Lastaccess;
                    loadedUser.SummonerInfo_ID = temp.SummonerInfo_ID;
                    loadedUser.UserInfo = Globals.GetSummonerInfo(temp.Summonername);

                    Globals.CurrentUser = loadedUser;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR {ex.Message}");
            }

            return res;
        }

        public async Task<Login> LoginUserAsync(string email, string pw)
        {
            ServerResponse.Login temp = new ServerResponse.Login();                               //Create a temporary json template
            Enums.Login res = Login.UnknownError;                                                 //Create a result enum object

            //Create the URL
            var uri = new Uri(string.Format(Constants.SERVER_URL + Constants.LOGIN_EXT));

            //Try to get results back
            try
            {
                var httpContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", email),
                    new KeyValuePair<string, string>("password", pw)
                });
                var response = await client.PostAsync(uri, httpContent);                              //Try to send the request

                //Check if request sent back success code
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();           //Read the content from the response

                    temp = JsonConvert.DeserializeObject<ServerResponse.Login>(content);     //Fill the temporary template

                    //Check if logged in was successful
                    if (temp.error == 0 && temp.success == 1)
                        res = Login.Success;                                            //Set res to be success
                    else if (temp.error == 1 && temp.success == 0)
                        res = Login.InvalidUsernamePassword;
                }
            }
            catch (Exception ex)
            {
                //In case of an error then debug it
                //TODO:Remove this line when publishing
                Debug.WriteLine("ERROR {0}", ex.Message);
            }

            return res;
        }

        public async Task<Register> RegisterUserAsync(NewUser user, SummonerInfo summoner)
        {
            ServerResponse.Register temp = new ServerResponse.Register();
            Enums.Register res = Register.UnknownError;

            var uri = new Uri(string.Format(Constants.SERVER_URL + Constants.REGISTER_EXT));

            try
            {
                var httpContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", user.Email),
                    new KeyValuePair<string, string>("summonername", user.SummonerName),
                    new KeyValuePair<string, string>("password", user.Password),
                    new KeyValuePair<string, string>("riot_id", summoner.id.ToString()),
                    new KeyValuePair<string, string>("account_id", summoner.accountId.ToString()),
                    new KeyValuePair<string, string>("profileicon_id", summoner.ProfileIconID.ToString()),
                    new KeyValuePair<string, string>("revisiondate", summoner.revisionDate.ToString()),
                    new KeyValuePair<string, string>("summonerlevel", summoner.summonerLevel.ToString()),
                });
                var response = await client.PostAsync(uri, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    temp = JsonConvert.DeserializeObject<ServerResponse.Register>(content);
                    res = temp.result; // Look at Enum.Register for result values
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR {ex.Message}");
            }

            return res;
        }

        public async Task<PasswordReset> ResetPasswordAsync(string email)
        {
            ServerResponse.PasswordReset temp = new ServerResponse.PasswordReset();                               //Create a temporary json template
            Enums.PasswordReset res = PasswordReset.UnknownError;                                       //Create a result enum object

            //Create the URL
            var uri = new Uri(string.Format(Constants.SERVER_URL + Constants.RESET_PASSWORD_EXT));

            //Try to get results back
            try
            {
                var httpContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", email)
                });
                var response = await client.PostAsync(uri, httpContent);                              //Try to send the request

                //Check if request sent back success code
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();           //Read the content from the response

                    temp = JsonConvert.DeserializeObject<ServerResponse.PasswordReset>(content);     //Fill the temporary template

                    switch (temp.errorCode)
                    {
                        case PasswordReset.EmailWasNotRecieved:
                            res = PasswordReset.EmailSentSuccessfully;
                            break;
                        case PasswordReset.UnknownError:
                            res = PasswordReset.UnknownError;
                            break;
                        case PasswordReset.EmailSentSuccessfully:
                            res = PasswordReset.EmailSentSuccessfully;
                            break;
                        case PasswordReset.ErrorSendingAnEmail:
                            res = PasswordReset.ErrorSendingAnEmail;
                            break;
                        default:
                            res = PasswordReset.UnknownError;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                //In case of an error then debug it
                //TODO:Remove this line when publishing
                Debug.WriteLine("ERROR {0}", ex.Message);
            }

            return res;
        }

        public async Task<Enums.ResendConfirmation> ResendConfirmationAsync(string email)
        {
            ServerResponse.ResendConfirmation temp = new ServerResponse.ResendConfirmation();                               //Create a temporary json template
            Enums.ResendConfirmation res = Enums.ResendConfirmation.UnknownError;                                       //Create a result enum object

            //Create the URL
            var uri = new Uri(string.Format(Constants.SERVER_URL + Constants.RESENT_CONFIRMATION_EMAIL_EXT));

            //Try to get results back
            try
            {
                var httpContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", email)
                });
                var response = await client.PostAsync(uri, httpContent);                              //Try to send the request

                //Check if request sent back success code
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();           //Read the content from the response

                    temp = JsonConvert.DeserializeObject<ServerResponse.ResendConfirmation>(content);     //Fill the temporary template

                    switch (temp.result)
                    {
                        case ResendConfirmation.IncorrectEmail:
                            res = Enums.ResendConfirmation.IncorrectEmail;
                            break;
                        case ResendConfirmation.ErrorUpdatingConfirmationDetails:
                            res = Enums.ResendConfirmation.ErrorUpdatingConfirmationDetails;
                            break;
                        case ResendConfirmation.ErrorSendingEmail:
                            res = Enums.ResendConfirmation.ErrorSendingEmail;
                            break;
                        case ResendConfirmation.SuccessfullySentConfirmationEmail:
                            res = ResendConfirmation.SuccessfullySentConfirmationEmail;
                            break;
                        case ResendConfirmation.UnknownError:
                        default:
                            res = ResendConfirmation.UnknownError;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                //In case of an error then debug it
                //TODO:Remove this line when publishing
                Debug.WriteLine("ERROR {0}", ex.Message);
            }

            return res;
        }
        #endregion
    }
}
