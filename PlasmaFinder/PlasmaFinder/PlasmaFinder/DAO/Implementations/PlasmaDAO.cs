using Newtonsoft.Json;
using PlasmaFinder.Constants;
using PlasmaFinder.DAO.Contracts;
using PlasmaFinder.Models;
using PlasmaFinder.Repository.Contracts;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlasmaFinder.DAO.Implementations
{
    public class PlasmaDAO : IPlasmaDAO
    {
        //private readonly ISQLliteRepository _localDatabase;
        //public LoginDAO(ISQLliteRepository localDatabase)
        //{
        //    _localDatabase = localDatabase;
        //}

        private readonly IApisRepository _apis;
        public PlasmaDAO(IApisRepository apis)
        {
            _apis = apis;
        }

        public async Task<bool> SavePlasma(SubmitResource resource)
        {
            //  var abc = await _apis.SendAsync<SubmitResource>(ApiConstants.API_BASE_URL + ApiConstants.ACTION_TYPE_ADD_RESOURCE,JsonConvert.SerializeObject(resource), HttpMethod.Post, "");
            var abc = await _apis.GetAsync<string>(ApiConstants.URL_ACTION_TYPE_AUTHVALUES, "", false);
            return true;
        }
    }
}
