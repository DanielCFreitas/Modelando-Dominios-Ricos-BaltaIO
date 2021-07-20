using Flunt.Validations;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Contracts
{
    public class CreatePaymentContract : Contract<Payment>
    {
        public CreatePaymentContract(Payment payment)
        {
            Requires()
                .IsLowerOrEqualsThan(0, payment.Total, "Payment.Total", "O total não pode ser zero")
                .IsGreaterOrEqualsThan(payment.Total, payment.TotalPaid, "Payment.TotalPaid", "O valor pago é menor que o valor total");
        }
    }
}
