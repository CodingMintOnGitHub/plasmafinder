using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using PlasmaFinder.Repository.Contracts;
using PlasmaFinder.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaFinder
{
    public class CoreAppStart : MvxAppStart
    {
        private readonly IMvxNavigationService _navigationService;

        private readonly ISQLliteRepository _sQLliteRepository;
        public CoreAppStart(IMvxApplication application,
                            IMvxNavigationService navigationService,
                            ISQLliteRepository sQLliteRepository)
            : base(application, navigationService)
        {
            _navigationService = navigationService;
            _sQLliteRepository = sQLliteRepository;
        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            // var serverDetail = Task.Factory.StartNew(() => CheckServerDetails().GetAwaiter().GetResult());
            // serverDetail.Wait();
            //if (serverDetail.Result)
            //{

            //}

            //  var provisioning = Task.Factory.StartNew(() => CheckProvisioningData().GetAwaiter().GetResult());
            //  provisioning.Wait();

            //if (provisioning.Result)
            //{
            //    return NavigationService.Navigate<StartupTestsViewModel>();
            //}
            //else
            //{
            //    return NavigationService.Navigate<ProvisioningViewModel>();
            //}

            return NavigationService.Navigate<AddPlasmaViewModel>();
        }
    }
}
