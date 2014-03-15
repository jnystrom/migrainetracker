using System;
using System.Collections.Generic;

namespace Gazallion.MigraineManager.Data.Models
{
    public class Medicine
    {
        public Medicine()
        {
            this.MedHistories = new List<MedHistory>();
            this.UserMeds = new List<UserMed>();
        }

        public int MedId { get; set; }
        public int MedTypeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MedHistory> MedHistories { get; set; }
        public virtual MedType MedType { get; set; }
        public virtual ICollection<UserMed> UserMeds { get; set; }
    }
}
