using Application.Payments.Enum;
using Application.Payments.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payments.DTOs
{
    public class PaymentDto
    {
        public string PaymentId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string Message { get; set; }
        public StatusPayment Status { get; set; }
        public TypePayment TypePayment { get; set; }
    }
}
