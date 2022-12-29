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
    public class DashboardViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _mvxNavigationService;
        private readonly MvxSubscriptionToken _token;
        private readonly IMvxMessenger _mvxMessenger;

        public DashboardViewModel(IMvxNavigationService mvxNavigationService, IMvxMessenger mvxMessenger)
        {
            _mvxNavigationService = mvxNavigationService;
            _mvxMessenger = mvxMessenger;
        }

        public IMvxAsyncCommand<string> TypeCommand => new MvxAsyncCommand<string>(TypeCommand_Handler);

        private async Task TypeCommand_Handler(string type)
        {
            await _mvxNavigationService.Navigate<SearchItemViewModel>();
        }
    }
}
