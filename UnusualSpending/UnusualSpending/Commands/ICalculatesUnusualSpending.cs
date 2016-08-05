using System.Collections.Generic;
using UnusualSpending.Values;

namespace UnusualSpending.Commands {
    public interface ICalculatesUnusualSpending {
        IList<UnusualPayments> Calculate(ISet<Payment> lastMonth, ISet<Payment> thisMonth);
    }
}