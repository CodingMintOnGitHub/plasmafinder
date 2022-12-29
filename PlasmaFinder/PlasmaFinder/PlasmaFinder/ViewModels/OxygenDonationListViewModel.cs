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
    public class OxygenDonationListViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _mvxNavigationService;
        private readonly MvxSubscriptionToken _token;
        private readonly IMvxMessenger _mvxMessenger;

        public OxygenDonationListViewModel(IMvxNavigationService mvxNavigationService, IMvxMessenger mvxMessenger)
        {
            _mvxNavigationService = mvxNavigationService;
            _mvxMessenger = mvxMessenger;
        }

        private bool _isMaleSelected = false;
        public bool IsMaleSelected
        {
            get { return _isMaleSelected; }
            set
            { 
                SetProperty(ref _isMaleSelected, value);
                if (IsMaleSelected)
                {
                    IsFeMaleSelected = false;
                    RaisePropertyChanged("IsFeMaleSelected");
                }
            }
        }

        private bool _isTestNegative = false;
        public bool IsTestNegative
        {
            get { return _isTestNegative; }
            set
            {
                SetProperty(ref _isTestNegative, value);
               
            }
        }

        private bool _isDischargeReportPresent = false;
        public bool IsDischargeReportPresent
        {
            get { return _isDischargeReportPresent; }
            set
            {
                SetProperty(ref _isDischargeReportPresent, value);

            }
        }

        private bool _isFeMaleSelected = false;
        public bool IsFeMaleSelected
        {
            get { return _isFeMaleSelected; }
            set 
            { 
                SetProperty(ref _isFeMaleSelected, value);
                if (IsFeMaleSelected)
                {
                    IsMaleSelected = false;
                    RaisePropertyChanged("IsMaleSelected");
                }
            }
        }

        public IMvxAsyncCommand<string> GenderCommand => new MvxAsyncCommand<string>(GenderCommand_Handler);
        private async Task GenderCommand_Handler(string param)
        {
            IsMaleSelected = false;
            IsFeMaleSelected = false;

            if (param == "M")
            {
                IsMaleSelected = true;
            }
            else if(param == "F")
            {
                IsFeMaleSelected = true;
            }

            await RaisePropertyChanged("IsMaleSelected");
            await RaisePropertyChanged("IsFeMaleSelected");
            //await _mvxNavigationService.Close(this);
        }

        public IMvxAsyncCommand<string> SubmitCommand => new MvxAsyncCommand<string>(SubmitCommand_Handler);
        private async Task SubmitCommand_Handler(string param)
        {
            await _mvxNavigationService.Navigate<AddClothesViewModel>();
        }
    }
}
