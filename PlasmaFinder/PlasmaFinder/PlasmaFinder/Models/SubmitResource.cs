using System;
using System.Collections.Generic;
using System.Text;

namespace PlasmaFinder.Models
{
    public class SubmitResource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Type { get; set; }
        public bool IsVerified { get; set; }
        public bool IsChargeble { get; set; }
        public bool IsRecoveryReport { get; set; }
        public DateTime RecoveryDate { get; set; }
        public DateTime CovidRecoveryDate { get; set; }
        public bool IsDifferentUser { get; set; }
        public bool IsNewResourceUser { get; set; }
        public string ExistingResourceUserId { get; set; }
        public ResourceUser ResourceUser { get; set; }
    }

    public class ResourceUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Picture { get; set; }
        public string Pincode { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public long AadhaarNumber { get; set; }
        public int Gender { get; set; }
        public int BloodGroup { get; set; }
        public DateTime DateOfRecovery { get; set; }
        public bool DischargeReport { get; set; }
        public bool CovidNegative { get; set; }

    }
}
