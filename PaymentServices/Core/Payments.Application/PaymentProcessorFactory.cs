using Application.Payment.DTOs;
using Application.Payment.Ports;
using Payments.Application.MercadoPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Application
{
    public class PaymentProcessorFactory : IPaymentProcessorFactory
    {
        public IPaymentProcessor GetPaymentProcessor(ProviderPayment selected)
        {
            switch (selected)
            {
                case ProviderPayment.MercadoPago:
                    return new MercadoPagoAdapter();

                default: return null;
            }
        }
    }
}
