using Pheko.Common.DataTransformObjects;

using Pheko.WebPresentation.ViewModels;

namespace Pheko.WebPresentation.MappingViewModelsToDtos
{
    public class SecurityUserViewModelMapper
    {
        public SecurityUserViewModelMapper() { }

        public SecurityUserDto MapToSecurityUserDto(SecurityUserViewModel securityUserViewModel)
        {
            if (securityUserViewModel == null)
            {
                return null;
            }

            SecurityUserDto securityUserDto = new SecurityUserDto();

            securityUserDto.SecurityUserId = securityUserViewModel.SecurityUserId;
            securityUserDto.UserName = securityUserViewModel.UserName;
            securityUserDto.Title = securityUserViewModel.Title;
            securityUserDto.Initials = securityUserViewModel.Initials;
            securityUserDto.FirstName = securityUserViewModel.FirstName;
            securityUserDto.LastName = securityUserViewModel.LastName;
            securityUserDto.IDNumber = securityUserViewModel.IDNumber;
            securityUserDto.BirthDate = securityUserViewModel.BirthDate;
            securityUserDto.Gender = securityUserViewModel.Gender;
            securityUserDto.WorkTelephoneCode = securityUserViewModel.WorkTelephoneCode;
            securityUserDto.WorkTelephoneNumber = securityUserViewModel.WorkTelephoneNumber;
            securityUserDto.FaxCode = securityUserViewModel.FaxCode;
            securityUserDto.FaxNumber = securityUserViewModel.FaxNumber;
            securityUserDto.MobileNumber = securityUserViewModel.MobileNumber;
            securityUserDto.EmailAddress = securityUserViewModel.EmailAddress;
            securityUserDto.EmployeeNumber = securityUserViewModel.EmployeeNumber;
            securityUserDto.DisabledDate = securityUserViewModel.DisabledDate;
            securityUserDto.PasswordSalt = securityUserViewModel.PasswordSalt;
            securityUserDto.Password = securityUserViewModel.Password;
            securityUserDto.FirstTimeLogInInd = securityUserViewModel.FirstTimeLogInInd;

            return securityUserDto;
        }

        public SecurityUserViewModel MapToPatientAddressViewModel(SecurityUserDto securityUserDto)
        {
            if (securityUserDto == null)
            {
                return null;
            }

            SecurityUserViewModel securityUserViewModel = new SecurityUserViewModel();

            securityUserViewModel.SecurityUserId = securityUserDto.SecurityUserId;
            securityUserViewModel.UserName = securityUserDto.UserName;
            securityUserViewModel.Title = securityUserDto.Title;
            securityUserViewModel.Initials = securityUserDto.Initials;
            securityUserViewModel.FirstName = securityUserDto.FirstName;
            securityUserViewModel.LastName = securityUserDto.LastName;
            securityUserViewModel.IDNumber = securityUserDto.IDNumber;
            securityUserViewModel.BirthDate = securityUserDto.BirthDate;
            securityUserViewModel.Gender = securityUserDto.Gender;
            securityUserViewModel.WorkTelephoneCode = securityUserDto.WorkTelephoneCode;
            securityUserViewModel.WorkTelephoneNumber = securityUserDto.WorkTelephoneNumber;
            securityUserViewModel.FaxCode = securityUserDto.FaxCode;
            securityUserViewModel.FaxNumber = securityUserDto.FaxNumber;
            securityUserViewModel.MobileNumber = securityUserDto.MobileNumber;
            securityUserViewModel.EmailAddress = securityUserDto.EmailAddress;
            securityUserViewModel.EmployeeNumber = securityUserDto.EmployeeNumber;
            securityUserViewModel.DisabledDate = securityUserDto.DisabledDate;
            securityUserViewModel.PasswordSalt = securityUserDto.PasswordSalt;
            securityUserViewModel.Password = securityUserDto.Password;
            securityUserViewModel.FirstTimeLogInInd = securityUserDto.FirstTimeLogInInd;

            return securityUserViewModel;
        }
    }
}
