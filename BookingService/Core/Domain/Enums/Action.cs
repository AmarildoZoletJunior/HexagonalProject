using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum Action
    {
        Pay = 1,
        Finish = 2,  //Depois de pagar e usar
        Cancel = 3, //Apenas do criado para cancelado
        Refund = 4, // Apenas somente se vier de pago
        Reopen = 5 // Cancelado
    }
}
