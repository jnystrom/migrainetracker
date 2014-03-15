using System;
using System.Collections.Generic;

namespace Gazallion.MigraineManager.Data.Models
{
    public class Condition
    {
        public Condition()
        {
            this.MedHistories = new List<MedHistory>();
            this.UserConditions = new List<UserCondition>();
        }

        public int ConditionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<MedHistory> MedHistories { get; set; }
        public virtual ICollection<UserCondition> UserConditions { get; set; }
    }
}
