using System;
using System.Collections.Generic;
using System.Text;

namespace PlasmaFinder.Models
{
    public class BloodDonation
    {
        public int BloodDonationId { get; set; }
        public string BloodDonorName { get; set; }
        public string BloodDonorGender { get; set; }
        public string BloodDonorAddressLine { get; set; }
        public string BloodDonorPincode { get; set; }
        public string BloodDonorCity { get; set; }
        public string BloodDonorState { get; set; }
        public DateTime BloodDonorDOB { get; set; }
        public string BloodDonorAadharNumber { get; set; }
        public string BloodDonorBloodGroup { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
