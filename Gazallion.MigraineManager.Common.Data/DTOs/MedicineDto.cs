using System;
using System.Collections.Generic;
using System.Linq;

namespace Gazallion.MigraineManager.Common.Data.DTOs
{
    public class MedicineDto
    {
        public int MedId { get; set; }
        public int MedTypeId { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<MedHistory> MedHistories { get; set; }
        public virtual MedTypeDto MedType { get; set; }
        //public virtual ICollection<UserMed> UserMeds { get; set; }
    }
}