using System;

namespace ETL.DataAccess.Models
{
    public partial class DimClient
    {
        public int ClientKey { get; set; }
        public string ClientAlternateKey { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? CurrentFlag { get; set; }
        public int Etlid { get; set; }
    }
}
