using System;
using System.Collections.Generic;
using PlasmaFinder.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;

namespace PlasmaFinder.Views
{
    public partial class BloodDonationList : MvxContentPage<BloodDonationListViewModel>
    {
        public BloodDonationList()
        {
            InitializeComponent();

        }
    }
}
