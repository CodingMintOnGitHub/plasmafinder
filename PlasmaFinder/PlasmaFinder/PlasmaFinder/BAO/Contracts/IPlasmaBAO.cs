using PlasmaFinder.Models;
using System;
using System.Threading.Tasks;

namespace PlasmaFinder.BAO.Contracts
{
    public interface IPlasmaBAO
    {
        Task<bool> SavePlasma(SubmitResource resource);
        //Task<Employee> GetLoggedInUser();
        //Task<bool> LoginUser(Employee employee);
        //Task<bool> LogoutUser();
        //Task<bool> UpdateUserLastLocation(string lastLocationString, Location location);
        //Task<TagNet.Models.Locations.UserLastLocation> GetLastSelectedLocation();
        //Task<Enum> CheckLogin(string badgeNumber, string password, bool isRemember);
        //Task<bool> SetApplicationForLoggedInUser();
    }
}
