using Application.Errors;
using Application.Payments;
using Application.Payments.DTOs;
using Application.Payments.Enum;
using Application.Payments.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Application.MercadoPago
{
    public class MercadoPagoAdapter : IPaymentService
    {
        public Task<PaymentResponse> PayWithCreditCard(string paymentIntention)
        {
            var lista = new List<ErrorResponse>();
            if (string.IsNullOrEmpty(paymentIntention))
            {

                lista.Add(new ErrorResponse { ErrorMessages = "A string de payment não pode ser nula", ErrorType = "ParametersInvalid" });
                var response = new PaymentResponse
                {
                    ListMessages = lista,
                    Success = false
                };
                return Task.FromResult(response);
            }
            var dto = new PaymentDto
            {
                Message = "Successfully paid",
                PaymentId = "123",
                Status = (StatusPayment)1,
                 TypePayment = (TypePayment)1
            };

            var responseOk = new PaymentResponse
            {
                Success = true,
                Payment = dto
            };
            return Task.FromResult(responseOk);
        }
    }
}
