using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.DebtLoadService
{
    internal interface IEntityId
    {
        public long Id { get; set; }
    }
}
