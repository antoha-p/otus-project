using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DebtLoadService
{
    public class DebtLoadUser : IEntityId
    {
        public long Id { get; set; }
        public int INN { get; set; }
        public string PasportNo { get; set; }
        public int summ { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ResponseDate { get; set; }

    }
}
