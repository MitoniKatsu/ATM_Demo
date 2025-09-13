using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Domain.Models
{
    public abstract class Transaction
    {
        // TODO: implement Id when storing in Database
        //public int Id { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public int AccountNumber { get; set; }
        public double Amount { get; set; }
        public int? TargetAccountNumber { get; set; }
        public DateTime TransactionTime { get; set; } = DateTime.Now;
    }
}
