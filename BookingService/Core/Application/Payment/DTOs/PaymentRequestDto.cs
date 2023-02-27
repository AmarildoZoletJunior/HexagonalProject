using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payment.DTOs
{
    public enum ProviderPayment
    {
        Paypal = 1,
        PagSeguro = 2,
        MercadoPago = 3
    }
    public enum PaymentMethods
    {
        DebitCard = 1,
        CreditCard = 2,
        BankTransfer = 3
    }
    public class PaymentRequestDto
    {
        public int BookingId { get; set; }
        public string PaymentIntention { get; set; }
        public ProviderPayment SelectedProvider { get; set; }
        public PaymentMethods SelectedMethod { get; set; }
    }
}
