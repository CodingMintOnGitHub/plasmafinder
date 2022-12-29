using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Polly;
using Newtonsoft.Json;
using System.Text;
using MvvmCross.Navigation;
using PlasmaFinder.Repository.Contracts;
using PlasmaFinder.Exceptions;
using PlasmaFinder.Constants;

namespace PlasmaFinder.Repository.Implementations
{
    public class ApisRepository : IApisRepository
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ISQLliteRepository _localDB;
        private static bool isProcessing = false;
        public ApisRepository( ISQLliteRepository localDB, IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            _localDB = localDB;
        }

        public async Task<T> GetAsync<T>(string uri, string authToken = "", bool hasJsonResponse = false)
        {
            try
            {
                HttpClient httpClient = CreateHttpClient(authToken);
                string serializedResult = string.Empty;                

                  var responseMessage =  await httpClient.GetAsync(uri);

                if (responseMessage.IsSuccessStatusCode)
                {
                    serializedResult = await responseMessage.Content.ReadAsStringAsync();

                    if(serializedResult == string.Empty)
                    {
                        serializedResult = "Status: 200";
                    }

                        var data = JsonConvert.DeserializeObject<T>(serializedResult);
                        return data;
                }

                throw new HttpRequestExceptionEx(responseMessage.StatusCode, serializedResult);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
                return default;
            }
        }


        public async Task<T> PostAsync<TData,T>(string uri, TData data, string authToken = "")
        {
            try
            {
                HttpClient httpClient = CreateHttpClient(uri);
                HttpContent content;
                content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //content.Headers.Add("Authorization", "Bearer eyJhbGciOiJSUzI1NiIsImtpZCI6IkNFRTlDNDVDRThDNTYxNkM4MEI3Qzk5MjI0QTQzMUNGIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2MjExOTQxMTEsImV4cCI6MTYyMTE5NzcxMSwiaXNzIjoiaHR0cDovL2NvZGluZ21pbnQtY292aWQtcmVzb3VyY2UuaGVyb2t1YXBwLmNvbSIsImNsaWVudF9pZCI6InBob25lX251bWJlcl9hdXRoZW50aWNhdGlvbiIsInN1YiI6ImExMDk3YTJmLTFmNGYtNGRlYy1iNzgwLTU5ZmRjZDA5YTFlYyIsImF1dGhfdGltZSI6MTYyMTE5NDExMSwiaWRwIjoibG9jYWwiLCJqdGkiOiI0RTRCMzMyODUwRDk2MTcyOEJERTc2NzNDOThCRUQ3OCIsImlhdCI6MTYyMTE5NDExMSwic2NvcGUiOlsib3BlbmlkIiwib2ZmbGluZV9hY2Nlc3MiXSwiYW1yIjpbInNtcyJdfQ.R6OQbWtVUyjDaZ9qKIxS8eowwM-PoMl458qOvfOmV0ZA7__j9cr0Z46Po0xZHEG2afIoKOx8OYdkMgPBpcSuXIvrsX8olFz8uh5m2erWNXrKUYRhcEpWBH75_oNx7m6wThBpBDWry8mZYLZ6hVzPlgzg6cK0-BzW3nhwwraxv9q80jwz9zHQVQ_4CAH0caQCYtsfr4FJdIMeAE4dIrqcHqjBb4X2BdYDyVOAvMECyEIVqh3WluNlEWk_tOUFzPMMc2XbL5YtuHVyYp9nQQ9mGdUatlbpoC-vGuIIvZe9qhZEejV_iLPS2yFgL4UB4nbTWe34ModTtCY-s9R-7TK_qw");

                string jsonResult = string.Empty;


                var responseMessage = await httpClient.PostAsync(uri, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync();

                    var xml = JsonConvert.DeserializeObject<T>(jsonResult);
                    return xml;
                }



                // throw new HttpRequestExceptionEx(responseMessage.StatusCode, jsonResult);
                return default;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
                return default;
            }
        }

        public async Task<bool> CheckServerState(string uri)
        {
            try
            {
                HttpClient httpClient = new HttpClient() { BaseAddress = new Uri("https://tagnet.stratumglobal.com"),Timeout = TimeSpan.FromMilliseconds(4000)};
                string xmlResult = string.Empty;

                var responseMessage =  await httpClient.GetAsync("https://tagnet.stratumglobal.com");

                if (responseMessage.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch
            {            
                return false;
            }
        }
        private HttpClient CreateHttpClient(string authToken, bool isTextData = false)
        {
            authToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjgxRTY4NDEyNjBFQkM4M0M3NzU1NDdERjhERjY4NEEyIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2MjExOTY5OTksImV4cCI6MTYyMTIwMDU5OSwiaXNzIjoiaHR0cDovL2NvZGluZ21pbnQtY292aWQtcmVzb3VyY2UuaGVyb2t1YXBwLmNvbSIsImNsaWVudF9pZCI6InBob25lX251bWJlcl9hdXRoZW50aWNhdGlvbiIsInN1YiI6ImExMDk3YTJmLTFmNGYtNGRlYy1iNzgwLTU5ZmRjZDA5YTFlYyIsImF1dGhfdGltZSI6MTYyMTE5Njk5OSwiaWRwIjoibG9jYWwiLCJqdGkiOiIwQUNCRTdCMjdGNjc5RUFDRTM4MkZGODM0MzFCNDkzRSIsImlhdCI6MTYyMTE5Njk5OSwic2NvcGUiOlsib3BlbmlkIiwib2ZmbGluZV9hY2Nlc3MiXSwiYW1yIjpbInNtcyJdfQ.N1aOKEjb4Ecurs1hbXBeUihooFH5Imic9qWW_PYgGC4DZlTGXo2T1aa82K4df1d0sRyhruJhzI0Ed9bKtmQZ5Ii38Q_0vpfbETCgpkC1Vqu2DZhARGAioxZwNm0sCAPh0PRLTGW7S0Z_SAyY4_uSPUQC2Pse6w4XRmNJvZYl2fuFdAkfsfky-OHnnzsnwuuFDgSBZs7LzgOm6IaunKmzCOOWOsX7-lxlfGrsEH0KwpzIwVpEQhO58AtCRO8rivYT_F13JP2chiwrDU6x4mZL0pJWHcFjZwowRN0l5dcTC8xabvYXFXx43doXyW1aAVLzetQyZoeyoR-U0RmYFJF30Q";
            var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(ApiConstants.API_BASE_URL);

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
 
            if (!string.IsNullOrEmpty(authToken))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            }
            return httpClient;
        }

        public async Task<T> SendAsync<T>(string uri, string data, HttpMethod method, string authToken = "")
        {
            try
            {
                HttpClient client = CreateHttpClient(uri, true);                
                string stringResponse = string.Empty;
                HttpRequestMessage request = new HttpRequestMessage(method, uri);                
                request.Content = new StringContent(data,
                                        Encoding.UTF8,
                                        "application/json");//CONTENT-TYPE header

                var responseMessage = await client.SendAsync(request);

                if (responseMessage.IsSuccessStatusCode)
                {
                    stringResponse = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

                    var xml = JsonConvert.DeserializeObject<T>(stringResponse);
                    return xml;
                }

                if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                    responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new ServiceAuthenticationException(stringResponse);
                }

                throw new HttpRequestExceptionEx(responseMessage.StatusCode, stringResponse);                
            }
            catch (HttpRequestException ex)
            {
                return default;
            }
        }

        
        //public async Task RefreshTokenAsync()
        //{
   
        //        try
        //        {

        //            var userInfo = await _localDB.GetUserData();
        //            var refreshReq = new RefreshTokenRequest() { Token = userInfo.Token, RefreshToken = userInfo.RefreshToken };
        //            HttpClient client = CreateHttpClient(ApiConstants.API_BASE_URL, true);
        //            string stringResponse = string.Empty;
        //            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, ApiConstants.REFRESH_TOKEN);
        //            request.Content = new StringContent(JsonConvert.SerializeObject(refreshReq),
        //                                    Encoding.UTF8,
        //                                    "application/json");//CONTENT-TYPE header

        //            var responseMessage = await client.SendAsync(request);

        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            stringResponse = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

        //            var userData = JsonConvert.DeserializeObject<LoginResponseData>(stringResponse);

        //            if (userData != null && userData.Status)
        //            {
        //                var existingUserData = await _localDB.GetUserData();
        //                var isDeleted = await _localDB.DeleteUserData();

        //                if (isDeleted)
        //                {
        //                    var isSaved = await _localDB.SaveUserData(new DB.Models.Transaction.UserData()
        //                    {
        //                        Key = 0,
        //                        EmailId = existingUserData.EmailId,
        //                        LastLoginDate = existingUserData.LastLoginDate,
        //                        RefreshToken = userData.Data.RefreshToken,
        //                        Token = userData.Data.Token,
        //                        RoleId = existingUserData.RoleId,
        //                        UserCode = existingUserData.UserCode,
        //                        UserId = existingUserData.UserId
        //                    });
        //                }
        //            }
        //            else if (userData != null && userData.Status == false && userData.Message == ApiConstants.REFRESH_TOKEN_EXPIRED)
        //            {
        //                await _navigationService.Navigate<LoginViewModel>();
        //            }
        //        }
        //        else if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
        //        {
        //           await _navigationService.Navigate<LoginViewModel>();
        //        }

        //            isProcessing = false;
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            isProcessing = false;

        //        }
         
        //}

    }
}
