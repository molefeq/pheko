//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pheko.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class PatientMedicalMonitoring
    {
        public int PatientMedicalMonitoringId { get; set; }
        public int PatientConsultationId { get; set; }
        public int MedicalMonitoringId { get; set; }
        public string Value { get; set; }
    
        public virtual MedicalMonitoring MedicalMonitoring { get; set; }
        public virtual PatientConsultation PatientConsultation { get; set; }
    }
}
