using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.Models
{
    public class Deposit : Transaction
    {
        public override TransactionType TransactionType { get; set; } = TransactionType.DEPOSIT;
    }
}
