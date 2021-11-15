using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageWebAPP.Models
{
    public class BalanceModel
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public int? NomenclatureId { get; set; }
        public int? Count { get; set; }
        public int? ResponsibleId { get; set; }        
        public int? MovementTypeId { get; set; }
    }
}
