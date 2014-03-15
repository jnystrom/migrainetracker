using System;
using System.Collections.Generic;

namespace Gazallion.MigraineManager.Data.Models
{
    public class MedHistory
    {
        public MedHistory()
        {
            this.Diets = new List<Diet>();
        }

        public int MedHistoryId { get; set; }
        public int UserId { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public int ConditionId { get; set; }
        public Nullable<int> MedId { get; set; }
        public virtual Condition Condition { get; set; }
        public virtual ICollection<Diet> Diets { get; set; }
        public virtual Medicine Medicine { get; set; }
        public virtual User User { get; set; }
    }
}
