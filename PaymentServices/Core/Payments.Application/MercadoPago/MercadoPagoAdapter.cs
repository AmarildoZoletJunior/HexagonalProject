using Application;
using Application.Payment;
using Application.Payment.DTOs;
using Application.Payment.PaymentResponse;
using Application.Payment.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Application.MercadoPago
{
    public class MercadoPagoAdapter : IPaymentProcessor
    {
        public Task<ResponsePayment> CapturePayment(string paymentIntention)
        {
            if(paymentIntention == null)
            {
                var responseError = new ResponsePayment
                {
                    Success = false,
                      Message = "O paymentIntention esta nulo"

                };
                return Task.FromResult(responseError);
            }
            var dto = new PaymentStateDto
            {
                CreatedDate = DateTime.Now,
                PaymentId = "123",
                Status = Status.Success,
                 Message = $"Pagamento feito com sucesso {paymentIntention}"
            };
            var responseSuccess = new ResponsePayment
            {
                Data = dto,
                 Success = true
            };
            return Task.FromResult(responseSuccess);
        }
    }
}
