using System;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Contracts
{
    public class AddSubscriptionToStudentContract : Contract<Student>
    {
        private readonly Student _student;

        public AddSubscriptionToStudentContract(Student student, Subscription subscription)
        {
            _student = student;

            Requires()
                .IsFalse(hasSubscriptionActive(), "Student.Subscriptions", "Você já tem uma assinatura ativa")
                .IsGreaterThan(subscription.Payments.Count, 0, "Student.Subscription.Payments", "Essa assinatura não possui pagamentos");
        }

        private bool hasSubscriptionActive()
        {
            return _student.Subscriptions.Any(s => s.Active);
        }
    }
}
