using Pheko.Common.Enums;

using System;
using System.Collections.Generic;

namespace Pheko.Common.DataTransformObjects
{
    public class SecurityUserDto
    {
        public int? SecurityUserId { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Initials { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string WorkTelephoneCode { get; set; }
        public string WorkTelephoneNumber { get; set; }
        public string FaxCode { get; set; }
        public string FaxNumber { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public string EmployeeNumber { get; set; }
        public DateTime? DisabledDate { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] Password { get; set; }
        public bool FirstTimeLogInInd { get; set; }
        public CrudOperations CrudOperation { get; set; }

        public List<SecurityUserRoleDto> SecurityUserRoles { get; set; }
    }
}
