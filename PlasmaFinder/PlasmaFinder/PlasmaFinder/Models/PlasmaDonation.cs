using System;
using System.Collections.Generic;
using System.Text;

namespace PlasmaFinder.Models
{
    public class PlasmaDonation
    {
        public int PlasmaDonationId { get; set; }
        public string PlasmaDonorName { get; set; }
        public string PlasmaDonorGender { get; set; }
        public string PlasmaDonorAddressLine { get; set; }
        public string PlasmaDonorPincode { get; set; }
        public string PlasmaDonorCity { get; set; }
        public string PlasmaDonorState { get; set; }
        public DateTime PlasmaDonorDOB { get; set; }
        public DateTime PlasmaDonorDORecovery { get; set; }
        public bool HasDischargeReport { get; set; }
        public bool HasLatestCovidTestNegative { get; set; }
        public string PlasmaDonorAadharNumber { get; set; }
        public string PlasmaDonorBloodGroup { get; set; }
        public string CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
