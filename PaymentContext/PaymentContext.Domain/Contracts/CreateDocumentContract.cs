using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Contracts
{
    public class CreateDocumentContract : Contract<Document>
    {
        private readonly Document _document;

        public CreateDocumentContract(Document document)
        {
            _document = document;

            Requires()
                .IsTrue(Validate(), "Document.Number", "Documento inválido");
        }

        public bool Validate()
        {
            if (_document.Type == EDocumentType.CNPJ && _document.Number.Length == 14)
                return true;

            if (_document.Type == EDocumentType.CPF && _document.Number.Length == 11)
                return true;

            return false;
        }
    }
}
