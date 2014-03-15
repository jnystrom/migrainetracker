using System;
using System.Collections.Generic;

namespace Gazallion.MigraineManager.Data.Models
{
    public class User
    {
        public User()
        {
            this.Addresses = new List<Address>();
            this.Diets = new List<Diet>();
            this.MedHistories = new List<MedHistory>();
            this.UserConditions = new List<UserCondition>();
            this.UserMeds = new List<UserMed>();
        }

        public int UserId { get; set; }
        public string UserToken { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Diet> Diets { get; set; }
        public virtual ICollection<MedHistory> MedHistories { get; set; }
        public virtual ICollection<UserCondition> UserConditions { get; set; }
        public virtual ICollection<UserMed> UserMeds { get; set; }
    }
}
