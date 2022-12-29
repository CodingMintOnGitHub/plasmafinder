using System;
using System.Collections.Generic;
using System.Text;

namespace PlasmaFinder.Models
{
    public class FoodDonation
    {
        public int FoodDonationId { get; set; }
        public string FoodDonorName { get; set; }
        public string FoodDonorGender { get; set; }
        public string FoodDonorAddressLine { get; set; }
        public string FoodDonorPincode { get; set; }
        public string FoodDonorCity { get; set; }
        public string FoodDonorState { get; set; }
        public string CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
