using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Contracts
{
    public class CreateEmailContract : Contract<Email>
    {
        public CreateEmailContract(Email email)
        {
            Requires()
                .IsEmail(email.Address, "Email.Address", "O e-mail informado não é válido");
        }
    }
}