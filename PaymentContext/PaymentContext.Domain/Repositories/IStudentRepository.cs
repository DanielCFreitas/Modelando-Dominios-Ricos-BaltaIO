using PaymentContext.Domain.Entities;
using PaymentContext.Shared.Repository;

namespace PaymentContext.Domain.Repositories
{
    public interface IStudentRepository : IRepository<Student>
    {
        bool DocumentExists(string document);
        bool EmailExists(string email);

        void CreateSubscription(Student student);
    }
}
