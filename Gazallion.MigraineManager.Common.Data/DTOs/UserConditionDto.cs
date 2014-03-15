using System;
using System.Collections.Generic;
using System.Linq;


namespace Gazallion.MigraineManager.Common.Data.DTOs
{
    public class UserConditionDto
    {
        public int UserId { get; set; }
        public int ConditionId { get; set; }
        public Nullable<int> IncidentThreshold { get; set; }
        public Nullable<int> ThresholdTimePeriod { get; set; }
        public virtual ConditionDto Condition { get; set; }
       // public virtual User User { get; set; }
    }
}