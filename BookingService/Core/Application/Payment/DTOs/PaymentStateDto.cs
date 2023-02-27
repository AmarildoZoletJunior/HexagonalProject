using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payment.DTOs
{
    public enum Status
    {
        Success = 1,
        Failed = 2,
        Error = 3,
        Undefined = 4
    }
    public class PaymentStateDto
    {
        public Status Status { get; set; }
        public string PaymentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Message { get; set; }
    }
}
