using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaFinder.ViewModels
{
    public class PlasmaDonationListViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _mvxNavigationService;
        private readonly MvxSubscriptionToken _token;
        private readonly IMvxMessenger _mvxMessenger;

        public PlasmaDonationListViewModel(IMvxNavigationService mvxNavigationService, IMvxMessenger mvxMessenger)
        {
            _mvxNavigationService = mvxNavigationService;
            _mvxMessenger = mvxMessenger;
        }
    }
}
