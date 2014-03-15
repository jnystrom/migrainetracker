using System;
using System.Collections.Generic;

namespace Gazallion.MigraineManager.Data.Models
{
    public class Diet
    {
        public int DietId { get; set; }
        public int UserId { get; set; }
        public int MedHistoryId { get; set; }
        public string FoodItemName { get; set; }
        public virtual MedHistory MedHistory { get; set; }
        public virtual User User { get; set; }
    }
}
