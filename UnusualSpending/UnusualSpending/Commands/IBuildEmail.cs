using System.Collections.Generic;
using UnusualSpending.Values;

namespace UnusualSpending.Commands {
    public interface IBuildEmail {
        Email Build(IList<UnusualPayments> unusualPayments);
    }
}