using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Contracts
{
    public class CreateAddressContract : Contract<Address>
    {
        public CreateAddressContract(Address address)
        {
            Requires()
                .IsNullOrEmpty(address.City, "Address.City", "A Cidade deve ser informada");
        }
    }
}
