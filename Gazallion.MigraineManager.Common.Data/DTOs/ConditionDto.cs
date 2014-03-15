using System;
using System.Collections.Generic;
using System.Linq;

namespace Gazallion.MigraineManager.Common.Data.DTOs
{
    public class ConditionDto
    {
        public int ConditionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       // public virtual ICollection<MedHistory> MedHistories { get; set; }
       // public virtual ICollection<UserCondition> UserConditions { get; set; }
    }
}