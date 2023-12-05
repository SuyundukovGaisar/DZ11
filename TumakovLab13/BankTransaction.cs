using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TumakovLab13
{
    public class BankTransaction
    {
        public DateTime DateTime { get; }
        public decimal Sum { get; }
        internal BankTransaction(DateTime dateTime, decimal sum)
        {
            DateTime = dateTime;
            Sum = sum;
        }
    }
}
