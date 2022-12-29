using PlasmaFinder.BAO.Contracts;
using PlasmaFinder.DAO.Contracts;
using PlasmaFinder.Models;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace PlasmaFinder.BAO.Implementations
{
    public class PlasmaBAO : IPlasmaBAO
    {
        private readonly IPlasmaDAO _iPlasmaDAO;
        //public async Task<Employee> GetLoggedInUser()
        //{
        //    return await _loginDAO.GetLoggedInUser();
        //}

        public PlasmaBAO(IPlasmaDAO plasmaDAO)
        {
            _iPlasmaDAO = plasmaDAO;
        }

        public async Task<bool> SavePlasma(SubmitResource resource)
        {
            return await _iPlasmaDAO.SavePlasma(resource);
        }
    }
}
