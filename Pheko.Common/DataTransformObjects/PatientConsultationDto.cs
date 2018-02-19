using Pheko.Common.Enums;

using System;

namespace Pheko.Common.DataTransformObjects
{
    public class PatientConsultationDto
    {
        public int? PatientConsultationId { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string ConsultationStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public CrudOperations CrudOperation { get; set; }
    }
}
