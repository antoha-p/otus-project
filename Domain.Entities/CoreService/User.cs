using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CoreService
{
    public class User: IEntityId
    {
        public long Id { get; set; }
        public int INN { get; set; }
        public string PasportNo { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Income { get; set; }
        public bool IsCompany { get; set; }
    }
}
