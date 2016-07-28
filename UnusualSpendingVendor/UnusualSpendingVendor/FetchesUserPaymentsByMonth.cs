using System;
using System.Collections.Generic;

namespace UnusualSpendingVendor {
    public class FetchesUserPaymentsByMonth<T> {
        public ISet<T> Fetch(long userId, int year, int month) {
            throw new InvalidOperationException("Data access will be implemented by a different team later");
        }
    }
}