using Pheko.Common.DataTransformObjects;

using Pheko.DataAccess;

namespace Pheko.ServicePresentation.MapDtoToEntityObjects
{
    public class DoctorMapper
    {
        public DoctorMapper() { }

        public DoctorDto MapToDoctorDto(Doctor doctor)
        {
            if (doctor == null)
            {
                return null;
            }

            DoctorDto DoctorDto = new DoctorDto();

            DoctorDto.DoctorId = doctor.DoctorId;
            DoctorDto.FirstName = doctor.SecurityUser.FirstName;
            DoctorDto.LastName = doctor.SecurityUser.LastName;
            //DoctorDto.PractiseNumber = doctor.PractiseNumber;
            DoctorDto.SecurityUserId = doctor.SecurityUserId;

            return DoctorDto;
        }

        public Doctor MapToDoctor(DoctorDto doctorDto)
        {
            if (doctorDto == null)
            {
                return null;
            }

            Doctor Doctor = new Doctor();

            if (doctorDto.DoctorId != null)
            {
                Doctor.DoctorId = doctorDto.DoctorId.Value;
            }

            //Doctor.FirstName = doctorDto.FirstName;
            //Doctor.LastName = doctorDto.LastName;
            //Doctor.PractiseNumber = doctorDto.PractiseNumber;
            Doctor.SecurityUserId = doctorDto.SecurityUserId;

            return Doctor;
        }
          
    }
}
