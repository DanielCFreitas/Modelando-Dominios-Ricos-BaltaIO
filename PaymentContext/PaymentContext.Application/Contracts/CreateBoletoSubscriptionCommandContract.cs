using Flunt.Validations;
using PaymentContext.Application.Commands;

namespace PaymentContext.Application.Contracts
{
    public class CreateBoletoSubscriptionCommandContract : Contract<CreateBoletoSubscriptionCommand>
    {
        public CreateBoletoSubscriptionCommandContract(CreateBoletoSubscriptionCommand command)
        {
            Requires()
                .IsGreaterThan(command.FirstName, 3, "Command.FirstName", "Nome deve ter pelo menos 3 caracteres")
                .IsGreaterThan(command.LastName, 3, "Command.LastName", "Sobrenome deve ter pelo menos 3 caracteres")
                .IsLowerThan(command.FirstName, 40, "Command.FirstName", "Nome deve ter no máximo 40 caracteres")
                .IsLowerThan(command.LastName, 40, "Command.LastName", "Sobrenome deve ter no máximo 40 caracteres")
                .IsLowerOrEqualsThan(0, command.Total, "Command.Total", "O total não pode ser zero")
                .IsGreaterOrEqualsThan(command.Total, command.TotalPaid, "Command.TotalPaid", "O valor pago é menor que o valor total")
                .IsNullOrEmpty(command.City, "Command.City", "A Cidade deve ser informada");
        }
    }
}
