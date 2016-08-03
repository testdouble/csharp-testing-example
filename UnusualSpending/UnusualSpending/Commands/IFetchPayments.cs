using System.Collections.Generic;

namespace UnusualSpending.Commands {
    public interface IFetchPayments<T> {
        ISet<T> Fetch(long userId, int year, int month);
    }
}