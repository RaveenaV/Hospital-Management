//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Sample.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Patient
    {
        public string PatientName { get; set; }
        public string PatientLastName { get; set; }
        public string FatherName { get; set; }
        public string HusbandName { get; set; }
        public string GuardianName { get; set; }
        public string BloodGroup { get; set; }
        public string ContactNumber { get; set; }
        public string ContactNumber2 { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<int> Age { get; set; }
        public string Gender { get; set; }
        public int PatientKey { get; set; }
    }
}