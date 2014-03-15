using System;
using System.Collections.Generic;

namespace Gazallion.MigraineManager.Data.Models
{
    public class UserMed
    {
        public int UserMedId { get; set; }
        public int UserId { get; set; }
        public int MedId { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public virtual Medicine Medicine { get; set; }
        public virtual User User { get; set; }
    }
}
