using System;
using System.Collections.Generic;

namespace ETL.DataAccess.Models
{
    public partial class DimEmployee
    {
        public DimEmployee()
        {
            FactSales = new HashSet<FactSales>();
        }

        public int EmployeeKey { get; set; }
        public int? AlternateKey { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public string Prefix { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public string DepartmentName { get; set; }
        public string Dlnumber { get; set; }
        public string Dlstate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? CurrentFlag { get; set; }
        public string Etlid { get; set; }

        public virtual ICollection<FactSales> FactSales { get; set; }
    }
}
