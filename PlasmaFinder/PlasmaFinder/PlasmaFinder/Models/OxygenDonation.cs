using System;
using System.Collections.Generic;
using System.Text;

namespace PlasmaFinder.Models
{
    public class OxygenDonation
    {
        public int OxygenDonationId { get; set; }
        public string OxygenDonorName { get; set; }
        public string OxygenDonorGender { get; set; }
        public string OxygenDonorAddressLine { get; set; }
        public string OxygenDonorPincode { get; set; }
        public string OxygenDonorCity { get; set; }
        public string OxygenDonorState { get; set; }
        public string CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
