using System;
using System.Collections.Generic;

namespace Gazallion.MigraineManager.Data.Models
{
    public class MedType
    {
        public MedType()
        {
            this.Medicines = new List<Medicine>();
        }

        public int MedTypeId { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
