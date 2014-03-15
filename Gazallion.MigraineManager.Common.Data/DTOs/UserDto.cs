using System;
using System.Collections.Generic;
using System.Linq;

namespace Gazallion.MigraineManager.Common.Data.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string UserToken { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<AddressDto> Addresses { get; set; }
       // public ICollection<Diet> Diets { get; set; }
        //public ICollection<MedHistory> MedHistories { get; set; }
        public ICollection<UserConditionDto> UserConditions { get; set; }
        public ICollection<UserMedDto> UserMeds { get; set; }
    }
}