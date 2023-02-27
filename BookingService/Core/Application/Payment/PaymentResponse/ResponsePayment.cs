using Application.Payment.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payment.PaymentResponse
{
    public class ResponsePayment : Response
    {
        public PaymentStateDto Data { get; set; }
    }
}
