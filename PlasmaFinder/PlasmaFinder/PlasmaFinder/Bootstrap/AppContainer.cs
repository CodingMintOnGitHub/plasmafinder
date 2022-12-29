using MvvmCross;
using MvvmCross.IoC;
using PlasmaFinder.BAO.Contracts;
using PlasmaFinder.BAO.Implementations;
using PlasmaFinder.DAO.Contracts;
using PlasmaFinder.DAO.Implementations;
using PlasmaFinder.Repository.Contracts;
using PlasmaFinder.Repository.Implementations;

namespace PlasmaFinder.Bootstrap
{
    public class AppContainer
    {
        public static void RegisterDependencies()
        {
            //Mvx.IoCProvider.RegisterType<IXmlUtils, XmlUtils>();
            //Mvx.IoCProvider.RegisterType<IMessagingUtils, MessagingUtils>();
            Mvx.IoCProvider.RegisterType<IApisRepository, ApisRepository>();
            Mvx.IoCProvider.ConstructAndRegisterSingleton<ISQLliteRepository, SQLliteRepository>();
            Mvx.IoCProvider.RegisterType<IPlasmaDAO, PlasmaDAO>();
            Mvx.IoCProvider.RegisterType<IPlasmaBAO, PlasmaBAO>();


            //Mvx.IoCProvider.RegisterType<IEmployeeDAO, EmployeeDAO>();
            //Mvx.IoCProvider.RegisterType<IEmployeeBAO, EmployeeBAO>();
        }
    }
}
