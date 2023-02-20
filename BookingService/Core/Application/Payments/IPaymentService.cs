using Application.Payments.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payments
{
     public interface IPaymentService
    {
       public Task<PaymentResponse> PayWithCreditCard(string paymentIntention);

    }
}
