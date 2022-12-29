using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using PlasmaFinder.Constants;
using PlasmaFinder.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasmaFinder.ViewModels
{
    public class BloodDonationListViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _mvxNavigationService;
        private readonly MvxSubscriptionToken _token;
        private readonly IMvxMessenger _mvxMessenger;

        public ObservableCollection<BloodDonation> BloodDonations { get; set; }

        public BloodDonationListViewModel(IMvxNavigationService mvxNavigationService, IMvxMessenger mvxMessenger)
        {
            _mvxNavigationService = mvxNavigationService;
            _mvxMessenger = mvxMessenger;
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
            BindBloodDonations();
        }//ListHeight

        private int _listHeight = 0;
        public int ListHeight
        {
            get { return _listHeight; }
            set
            {
                SetProperty(ref _listHeight, value);               
            }
        }

        private const string defaultStateFilterText = "No Filter";
        private string _donorStateFilterText = defaultStateFilterText;
        public string DonorStateFilterText
        {
            get { return _donorStateFilterText; }
            set
            {
                SetProperty(ref _donorStateFilterText, value);
            }
        }

        private const string defaultDOBFilterText = "No Filter";
        private string _donorDOB = defaultDOBFilterText;
        public string DonorDOB
        {
            get { return _donorDOB; }
            set
            {
                SetProperty(ref _donorDOB, value);
            }
        }

        private bool _isFilterVisible = false;
        public bool IsFilterVisible
        {
            get { return _isFilterVisible; }
            set
            {
                SetProperty(ref _isFilterVisible, value);
            }
        }

        public void BindBloodDonations()
        {
            List<BloodDonation> donations = new List<BloodDonation>()
            {
                new BloodDonation()
                {
                    BloodDonationId = 1,
                    BloodDonorAadharNumber = "1111-1111-1111",
                    BloodDonorAddressLine = "12-D Frankie's Inn, Chowk",
                    BloodDonorBloodGroup = "O+",
                    BloodDonorCity = "Lucknow",
                    BloodDonorDOB = DateTime.Now,
                    BloodDonorGender = "Male",
                    BloodDonorName = "George Clooney",
                    BloodDonorPincode = "226001",
                    BloodDonorState = "Uttar Pradesh",
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = true
                },

                new BloodDonation()
                {
                    BloodDonationId = 1,
                    BloodDonorAadharNumber = "2222-2222-2222",
                    BloodDonorAddressLine = "13-C John's Shack, RK Nagar",
                    BloodDonorBloodGroup = "O+",
                    BloodDonorCity = "Kanpur",
                    BloodDonorDOB = DateTime.Now,
                    BloodDonorGender = "Female",
                    BloodDonorName = "Anna Hathway",
                    BloodDonorPincode = "245874",
                    BloodDonorState = "Uttar Pradesh",
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = true
                },

                  new BloodDonation()
                {
                    BloodDonationId = 1,
                    BloodDonorAadharNumber = "3333-33333-3333",
                    BloodDonorAddressLine = "113/76 Shyam Sweets, Aliganj",
                    BloodDonorBloodGroup = "AB-",
                    BloodDonorCity = "Lucknow",
                    BloodDonorDOB = DateTime.Now,
                    BloodDonorGender = "Male",
                    BloodDonorName = "Anand Mishra",
                    BloodDonorPincode = "226541",
                    BloodDonorState = "Uttar Pradesh",
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = true
                },

                    new BloodDonation()
                {
                    BloodDonationId = 1,
                    BloodDonorAadharNumber = "4444-4444-4444",
                    BloodDonorAddressLine = "13-C CMS School, Chowk",
                    BloodDonorBloodGroup = "B+",
                    BloodDonorCity = "Lucknow",
                    BloodDonorDOB = DateTime.Now,
                    BloodDonorGender = "Female",
                    BloodDonorName = "Diksha Sharma",
                    BloodDonorPincode = "226112",
                    BloodDonorState = "Uttar Pradesh",
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = true
                },
                           new BloodDonation()
                {
                    BloodDonationId = 1,
                    BloodDonorAadharNumber = "5555-5555-5555",
                    BloodDonorAddressLine = "14/667 Pioneer Saloon, HazratGanj",
                    BloodDonorBloodGroup = "A+",
                    BloodDonorCity = "Lucknow",
                    BloodDonorDOB = DateTime.Now,
                    BloodDonorGender = "Male",
                    BloodDonorName = "Kanishka Charan",
                    BloodDonorPincode = "226512",
                    BloodDonorState = "Uttar Pradesh",
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = true
                },  new BloodDonation()
                {
                    BloodDonationId = 1,
                    BloodDonorAadharNumber = "2222-2222-2222",
                    BloodDonorAddressLine = "13-C John's Shack, RK Nagar",
                    BloodDonorBloodGroup = "O+",
                    BloodDonorCity = "Kanpur",
                    BloodDonorDOB = DateTime.Now,
                    BloodDonorGender = "Female",
                    BloodDonorName = "Anna Hathway",
                    BloodDonorPincode = "245874",
                    BloodDonorState = "Uttar Pradesh",
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = true
                },

                  new BloodDonation()
                {
                    BloodDonationId = 1,
                    BloodDonorAadharNumber = "3333-33333-3333",
                    BloodDonorAddressLine = "113/76 Shyam Sweets, Aliganj",
                    BloodDonorBloodGroup = "AB-",
                    BloodDonorCity = "Lucknow",
                    BloodDonorDOB = DateTime.Now,
                    BloodDonorGender = "Male",
                    BloodDonorName = "Anand Mishra",
                    BloodDonorPincode = "226541",
                    BloodDonorState = "Uttar Pradesh",
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = true
                },

                    new BloodDonation()
                {
                    BloodDonationId = 1,
                    BloodDonorAadharNumber = "4444-4444-4444",
                    BloodDonorAddressLine = "13-C CMS School, Chowk",
                    BloodDonorBloodGroup = "B+",
                    BloodDonorCity = "Lucknow",
                    BloodDonorDOB = DateTime.Now,
                    BloodDonorGender = "Female",
                    BloodDonorName = "Diksha Sharma",
                    BloodDonorPincode = "226112",
                    BloodDonorState = "Uttar Pradesh",
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = true
                }
            };

            BloodDonations = new ObservableCollection<BloodDonation>(donations);
            RaisePropertyChanged("BloodDonations");

            ListHeight = 80 * BloodDonations.ToList().Count();
            RaisePropertyChanged("ListHeight");
        }


        public  IMvxAsyncCommand<BloodDonation> BloodDonationTapped => new MvxAsyncCommand<BloodDonation>(async(BloodDonation donation) =>
        {
            await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Alert", "Tapped :- " + donation.BloodDonorName, "Ok");
        });

        public IMvxAsyncCommand ToggleFilters => new MvxAsyncCommand(async() =>
         {
             IsFilterVisible = !IsFilterVisible;
             await RaisePropertyChanged("IsFilterVisible");
         });

        public IMvxAsyncCommand<string> SubmitCommand => new MvxAsyncCommand<string>(async (string actionType) =>
        {

            if(actionType == ApiConstants.ACTION_TYPE_CLEAR)
            {
                //reset all filters
            }

            IsFilterVisible = !IsFilterVisible;
            await RaisePropertyChanged("IsFilterVisible");
        });
    }
}
