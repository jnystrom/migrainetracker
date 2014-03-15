using System;
using System.Collections.Generic;

namespace Gazallion.MigraineManager.Data.Models
{
    public class UserCondition
    {
        public int UserId { get; set; }
        public int ConditionId { get; set; }
        public Nullable<int> IncidentThreshold { get; set; }
        public Nullable<int> ThresholdTimePeriod { get; set; }
        public virtual Condition Condition { get; set; }
        public virtual User User { get; set; }
    }
}
