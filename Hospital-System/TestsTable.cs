//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hospital_System
{
    using System;
    using System.Collections.Generic;
    
    public partial class TestsTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TestsTable()
        {
            this.PatientsTables = new HashSet<PatientsTable>();
        }
    
        public int TestID { get; set; }
        public int PatientID { get; set; }
        public string TestResults { get; set; }
        public System.DateTime TestDate { get; set; }
        public int DoctorID { get; set; }
    
        public virtual DoctorsTable DoctorsTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientsTable> PatientsTables { get; set; }
        public virtual PatientsTable PatientsTable { get; set; }
    }
}
