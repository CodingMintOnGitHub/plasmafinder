using System;
using System.Collections.Generic;
using System.Text;

namespace PlasmaFinder.Models
{
    public class ClothesDonation
    {
        public int ClothesDonationId { get; set; }
        public string ClothesDonorName { get; set; }
        public string ClothesDonorGender { get; set; }
        public string ClothesDonorAddressLine { get; set; }
        public string ClothesDonorPincode { get; set; }
        public string ClothesDonorCity { get; set; }
        public string ClothesDonorState { get; set; }
        public string CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
