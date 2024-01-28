using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CoreService
{
    public class ScorringResult : IEntityId
    {
        public long Id { get; set; }
        public string ScorringResultCode { get; set; }
    }
}
