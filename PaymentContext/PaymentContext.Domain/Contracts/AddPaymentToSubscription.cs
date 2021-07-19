using System;
using Flunt.Validations;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Contracts
{
    public class AddPaymentToSubscription : Contract<Payment>
    {
        public AddPaymentToSubscription(Payment payment)
        {
            Requires()
                .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "A data do pagamento deve ser futura");
        }
    }
}
