using Application.Payment.PaymentResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payment.Ports
{
    public interface IPaymentProcessor
    {
        Task<ResponsePayment> CapturePayment(string paymentIntention);
    }
}
