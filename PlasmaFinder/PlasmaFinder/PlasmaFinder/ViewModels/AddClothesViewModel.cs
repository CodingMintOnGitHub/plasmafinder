using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using PlasmaFinder.Constants;
using PlasmaFinder.Models;
using PlasmaFinder.MvxMessages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaFinder.ViewModels
{
    public class AddClothesViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _mvxNavigationService;
        private readonly MvxSubscriptionToken _token;
        private readonly IMvxMessenger _mvxMessenger;
        private const string defaultBloodGroupText = "ex: AB+";
        private const string defaultStateText = "ex: Uttar Pradesh [U.P]";
        private const string defaultCityText = "ex: Lucknow";

        public AddClothesViewModel(IMvxNavigationService mvxNavigationService, IMvxMessenger mvxMessenger)
        {
            _mvxNavigationService = mvxNavigationService;
            _mvxMessenger = mvxMessenger;
            _token = _mvxMessenger.SubscribeOnMainThread<ItemMessage>(SelectedItem_Handler);
            App.SELECTED_STATE_ID = "0";//reset
        }

        private string _cityText = defaultCityText;
        public string CityText
        {
            get { return _cityText; }
            set
            {
                SetProperty(ref _cityText, value);
            }
        }

        private string _cityValue = string.Empty;
        public string CityValue
        {
            get { return _cityValue; }
            set
            {
                SetProperty(ref _cityValue, value);
            }
        }

        private string _stateText = defaultStateText;
        public string StateText
        {
            get { return _stateText; }
            set
            {
                SetProperty(ref _stateText, value);
            }
        }

        private string _stateValue = string.Empty;
        public string StateValue
        {
            get { return _stateValue; }
            set
            {
                SetProperty(ref _stateValue, value);
            }
        }

        private string _bloodGroupText = defaultBloodGroupText;
        public string BloodGroupText
        {
            get { return _bloodGroupText; }
            set
            {
                SetProperty(ref _bloodGroupText, value);
            }
        }

        private string _bloodGroupValue = string.Empty;
        public string BloodGroupValue
        {
            get { return _bloodGroupValue; }
            set
            {
                SetProperty(ref _bloodGroupValue, value);
            }
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

        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        private string _aadharNumber = string.Empty;
        public string AadharNumber
        {
            get { return _aadharNumber; }
            set
            {
                SetProperty(ref _aadharNumber, value);
            }
        }

        private DateTime _dob = DateTime.Now;
        public DateTime Dob
        {
            get { return _dob; }
            set
            {
                SetProperty(ref _dob, value);
            }
        }

        private string _addressLine1 = string.Empty;
        public string AddressLine1
        {
            get { return _addressLine1; }
            set
            {
                SetProperty(ref _addressLine1, value);
            }
        }

        private string _pincode = string.Empty;
        public string Pincode
        {
            get { return _pincode; }
            set
            {
                SetProperty(ref _pincode, value);
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
        }

        public IMvxAsyncCommand<string> SubmitCommand => new MvxAsyncCommand<string>(SubmitCommand_Handler);
        private async Task SubmitCommand_Handler(string param)
        {

            //if (!IsModelValid())
            //{
            //    return;
            //}

            //var submit = new SubmitResource()
            //{
            //    Name = this.Name,
            //    CovidRecoveryDate = default,
            //    Description = string.Empty,
            //    ExistingResourceUserId = null,
            //    IsChargeble = false,
            //    IsDifferentUser = true,
            //    IsNewResourceUser = false,
            //    IsRecoveryReport = IsDischargeReportPresent,
            //    IsVerified = true,
            //    RecoveryDate = default,
            //    Price = 0,
            //    Type = (int)Resource_Type.Clothes, //clothes
            //    ResourceUser = new ResourceUser()
            //    {
            //        AadhaarNumber = default,
            //        Address = AddressLine1,
            //        BirthDate = Dob,
            //        BloodGroup = 0,
            //        CityId = Convert.ToInt32(CityValue),
            //        CovidNegative = IsTestNegative,
            //        DateOfRecovery = default,
            //        DischargeReport = IsDischargeReportPresent,
            //        Gender = IsMaleSelected ? (int)Gender_Type.Male : (int)Gender_Type.Female,
            //        LastName = string.Empty,
            //        Name = Name,
            //        Picture = default,
            //        Pincode = Pincode,
            //        StateId = Convert.ToInt32(StateValue),
            //    }
            //};


             await _mvxNavigationService.Navigate<AddFoodViewModel>();
        }

        private bool IsModelValid()
        {
            if (string.IsNullOrEmpty(Name))
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alert", "Please enter donor's name", "Okay");
                return false;
            }

            if (string.IsNullOrEmpty(AddressLine1))
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alert", "Please enter donor's address", "Okay");
                return false;
            }

            if (string.IsNullOrEmpty(Pincode))
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alert", "Please enter donor's pincode", "Okay");
                return false;
            }

            if (!string.IsNullOrEmpty(Pincode) && Pincode.Length < 6)
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alert", "Please enter donor's correct pincode", "Okay");
                return false;
            }

            if (string.IsNullOrEmpty(StateValue))
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alert", "Please select donor's state", "Okay");
                return false;
            }

            if (string.IsNullOrEmpty(CityValue))
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alert", "Please select donor's city", "Okay");
                return false;
            }

            if (!IsMaleSelected && !IsFeMaleSelected)
            {
                Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alert", "Please select donor's gender", "Okay");
                return false;
            }

            return true;
        }

        private void SelectedItem_Handler(ItemMessage item)
        {
            switch (item.SelectedItem.ItemType)
            {

                case "bloodType":
                    BloodGroupText = Convert.ToString(item.SelectedItem.ItemText);
                    BloodGroupValue = item.SelectedItem.ItemKey;
                    RaisePropertyChanged("BloodGroupValue");
                    RaisePropertyChanged("BloodGroupText");
                    break;

                case "stateType":
                    StateText = Convert.ToString(item.SelectedItem.ItemText);
                    StateValue = item.SelectedItem.ItemKey;
                    App.SELECTED_STATE_ID = item.SelectedItem.ItemKey;
                    RaisePropertyChanged("StateValue");
                    RaisePropertyChanged("StateText");
                    break;

                case "cityType":
                    CityText = Convert.ToString(item.SelectedItem.ItemText);
                    CityValue = item.SelectedItem.ItemKey;
                    RaisePropertyChanged("CityText");
                    RaisePropertyChanged("CityValue");
                    break;
            }
        }

        public IMvxAsyncCommand<string> SelectBloodGroup => new MvxAsyncCommand<string>(SelectBloodGroup_Handler);
        private async Task SelectBloodGroup_Handler(string param)
        {
            await _mvxNavigationService.Navigate<SelectListItemViewModel, string>("bloodType");
        }

        public IMvxAsyncCommand<string> SelectStateText => new MvxAsyncCommand<string>(SelectStateText_Handler);
        private async Task SelectStateText_Handler(string param)
        {
            await _mvxNavigationService.Navigate<SelectListItemViewModel, string>("stateType");
        }

        public IMvxAsyncCommand<string> SelectCityText => new MvxAsyncCommand<string>(SelectCityText_Handler);
        private async Task SelectCityText_Handler(string param)
        {
            await _mvxNavigationService.Navigate<SelectListItemViewModel, string>("cityType");
        }
    }
}
