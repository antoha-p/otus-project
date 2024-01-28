using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.CoreService
{
    public class Request : IEntityId
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime RequestDate { get; set; }
        public int PaymentAmount { get; set; }
        public bool IsBlocked { get; set; }
        public float AverageOverduePaymentCount { get; set; }
        public int ScorringResultId { get; set; }
        public int RequestAmount { get; set; }

        public User User { get; set; } // Связь с моделью User

        public ScorringResult ScorringResult { get; set; } // Связь с моделью ScorringResult
    }
}
