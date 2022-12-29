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
    public class VerifyOTPViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _mvxNavigationService;
        private readonly MvxSubscriptionToken _token;
        private readonly IMvxMessenger _mvxMessenger;

        public VerifyOTPViewModel(IMvxNavigationService mvxNavigationService, IMvxMessenger mvxMessenger)
        {
            _mvxNavigationService = mvxNavigationService;
            _mvxMessenger = mvxMessenger;
        }

        public IMvxAsyncCommand LoginCommand => new MvxAsyncCommand(LoginCommand_Handler);

        private async Task LoginCommand_Handler()
        {
            await _mvxNavigationService.Navigate<DashboardViewModel>();
        }
    }
}
