using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageWebAPP.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public OperationTypes OperationType { get; set; }
        public double Count { get; set; }
        public virtual Nomenclature Nomenclature { get; set; }
        public virtual Account Account { get; set; }

    }

    public enum OperationTypes
    {
        Receiving,
        Shipping
    }
}
