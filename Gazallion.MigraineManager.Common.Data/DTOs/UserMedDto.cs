using System;
using System.Collections.Generic;
using System.Linq;

namespace Gazallion.MigraineManager.Common.Data.DTOs
{
    public class UserMedDto
    {
        public int UserMedId { get; set; }
        public int UserId { get; set; }
        public int MedId { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public virtual MedicineDto Medicine { get; set; }
       // public virtual User User { get; set; }
    }
}