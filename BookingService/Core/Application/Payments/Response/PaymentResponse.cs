using Application.Payments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payments.Response
{
    public class PaymentResponse : Application.Response
    {
        public PaymentDto Payment { get; set; }
    }
}
