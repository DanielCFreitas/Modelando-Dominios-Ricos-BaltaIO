using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Contracts
{
    public class AddSubscriptionToStudentContract : Contract<Student>
    {
        private readonly Student _student;

        public AddSubscriptionToStudentContract(Student student)
        {
            _student = student;

            Requires()
                .IsFalse(HasSubscriptionActive(), "Student.Active", "Você já tem uma assinatura ativa");
        }

        public bool HasSubscriptionActive()
        {
            return _student.Subscriptions.Any(s => s.Active);
        }
    }
}
