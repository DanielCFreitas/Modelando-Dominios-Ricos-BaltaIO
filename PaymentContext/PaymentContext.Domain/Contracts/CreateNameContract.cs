using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Contracts
{
    public class CreateNameContract : Contract<Name>
    {
        public CreateNameContract(Name name)
        {
            Requires()
                .IsGreaterThan(name.FirstName, 3, "Name.FirstName", "Nome deve ter pelo menos 3 caracteres")
                .IsGreaterThan(name.LastName, 3, "Name.LastName", "Sobrenome deve ter pelo menos 3 caracteres")
                .IsLowerThan(name.FirstName, 40, "Name.FirstName", "Nome deve ter no máximo 40 caracteres")
                .IsLowerThan(name.LastName, 40, "Name.LastName", "Sobrenome deve ter no máximo 40 caracteres");
        }
    }
}
