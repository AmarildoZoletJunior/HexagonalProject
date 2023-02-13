using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum Action
    {
        Pay = 0,
        Finish = 1,  //Depois de pagar e usar
        Cancel = 2, //Apenas do criado para cancelado
        Refund = 3, // Apenas somente se vier de pago
        Reopen = 4 // Cancelado
    }
}
