using PlasmaFinder.Models;
using System;
using System.Threading.Tasks;


namespace PlasmaFinder.DAO.Contracts
{
    public interface IPlasmaDAO
    {
        Task<bool> SavePlasma(SubmitResource resource);
        //Task<Employee> GetLoggedInUser();
        //Task<bool> LoginUser(Employee employee);
        //Task<bool> LogoutUser();
        //Task<bool> UpdateUserLastLocation(string lastLocationString, TagNet.Models.TagMovements.Location location);
        //Task<UserLastLocation> GetLastSelectedLocation();
        //Task<Employee> FindEmployeeByBadgeNumber(string badgeNumber);
    }
}
