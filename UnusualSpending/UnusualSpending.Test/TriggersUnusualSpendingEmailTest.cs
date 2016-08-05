using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using UnusualSpending.Commands;
using UnusualSpending.Values;

namespace UnusualSpending.Test {
    public class TriggersUnusualSpendingEmailTest {
        private readonly Mock<IFetchPayments<Payment>> _fetchPaymentMock = new Mock<IFetchPayments<Payment>>();
        private readonly Mock<IGetsCurrentDate> _getDateMock = new Mock<IGetsCurrentDate>();
        private readonly Mock<ICalculatesUnusualSpending> _unusualSpendingMock = new Mock<ICalculatesUnusualSpending>();
        private readonly Mock<IEmailsUsers> _emailsUsersMock = new Mock<IEmailsUsers>();
        private readonly Mock<IBuildEmail> _buildEmailMock = new Mock<IBuildEmail>();

        [Fact]
        public void HasUnusualPayments() {
            var userId = 1;
            var today = DateTime.Today;
            var paymentsLastMonth = new HashSet<Payment>();
            var paymentsThisMonth = new HashSet<Payment>();
            var unusualPayment = new UnusualPayments();
            var unusualPayments = new List<UnusualPayments> { unusualPayment };
            var email = new Email {
                Subject = "Unusual Spending",
                Body = "You spent too much money!"
            };
            _getDateMock.Setup(m => m.GetCurrentDate()).Returns(today);
            _fetchPaymentMock.Setup(m => m.Fetch(userId, today.Year, today.Month - 1)).Returns(paymentsLastMonth);
            _fetchPaymentMock.Setup(m => m.Fetch(userId, today.Year, today.Month)).Returns(paymentsThisMonth);
            _unusualSpendingMock.Setup(m => m.Calculate(paymentsLastMonth, paymentsThisMonth)).Returns(unusualPayments);
            _buildEmailMock.Setup(m => m.Build(unusualPayments)).Returns(email);
            var subject = new TriggersUnusualSpendingEmail(
                _fetchPaymentMock.Object,
                _getDateMock.Object,
                _unusualSpendingMock.Object,
                _emailsUsersMock.Object,
                _buildEmailMock.Object);

            subject.Trigger(userId);

            _emailsUsersMock.Verify(m => m.Email(userId, email.Subject, email.Body));
        }

        [Fact]
        public void DoesNotHaveUnusualPayments() {
            var userId = 1;
            var today = DateTime.Today;
            var paymentsLastMonth = new HashSet<Payment>();
            var paymentsThisMonth = new HashSet<Payment>();
            var emptyUnusualPayments = new List<UnusualPayments>();
            _getDateMock.Setup(m => m.GetCurrentDate()).Returns(today);
            _fetchPaymentMock.Setup(m => m.Fetch(userId, today.Year, today.Month - 1)).Returns(paymentsLastMonth);
            _fetchPaymentMock.Setup(m => m.Fetch(userId, today.Year, today.Month)).Returns(paymentsThisMonth);
            _unusualSpendingMock.Setup(m => m.Calculate(paymentsLastMonth, paymentsThisMonth)).Returns(emptyUnusualPayments);
            var subject = new TriggersUnusualSpendingEmail(
                _fetchPaymentMock.Object,
                _getDateMock.Object,
                _unusualSpendingMock.Object,
                _emailsUsersMock.Object,
                _buildEmailMock.Object);

            subject.Trigger(userId);

            _emailsUsersMock.Verify(m => m.Email(userId, It.IsAny<string>(), It.IsAny<string>()), Times.Never());
        }
    }
}
