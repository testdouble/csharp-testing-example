using System.Linq;
using UnusualSpending.Commands;
using UnusualSpending.Values;

namespace UnusualSpending {
    public class TriggersUnusualSpendingEmail {
        private readonly IFetchPayments<Payment> _fetchPayments;
        private readonly IGetsCurrentDate _getDate;
        private readonly ICalculatesUnusualSpending _calculatesUnusualSpending;
        private readonly IEmailsUsers _emailsUsers;
        private readonly IBuildEmail _buildsEmail;

        public TriggersUnusualSpendingEmail(IFetchPayments<Payment> fetchPayments, IGetsCurrentDate getDate, ICalculatesUnusualSpending calculatesUnusualSpending, IEmailsUsers emailsUsers, IBuildEmail buildsEmail) {
            _fetchPayments = fetchPayments;
            _getDate = getDate;
            _calculatesUnusualSpending = calculatesUnusualSpending;
            _emailsUsers = emailsUsers;
            _buildsEmail = buildsEmail;
        }

        public void Trigger(long userId) {
            var today = _getDate.GetCurrentDate();
            var paymentsLastMonth = _fetchPayments.Fetch(userId, today.Year, today.Month - 1);
            var paymentsThisMonth = _fetchPayments.Fetch(userId, today.Year, today.Month);
            var unusualPayments = _calculatesUnusualSpending.Calculate(paymentsLastMonth, paymentsThisMonth);
            if (unusualPayments.Any()) {
                var email = _buildsEmail.Build(unusualPayments);
                _emailsUsers.Email(userId, email.Subject, email.Body);
            }
        }
    }
}
