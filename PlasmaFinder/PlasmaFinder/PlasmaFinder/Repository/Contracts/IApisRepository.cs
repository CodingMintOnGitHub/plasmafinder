using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlasmaFinder.Repository.Contracts
{
    public interface IApisRepository
    {
        Task<T> GetAsync<T>(string uri, string authToken = "", bool hasJsonResponse = false);
        Task<T> PostAsync<TData, T>(string uri, TData data, string authToken = "");

        Task<T> SendAsync<T>(string uri, string data, HttpMethod method, string authToken = "");
        Task<bool> CheckServerState(string uri);
    }
}
