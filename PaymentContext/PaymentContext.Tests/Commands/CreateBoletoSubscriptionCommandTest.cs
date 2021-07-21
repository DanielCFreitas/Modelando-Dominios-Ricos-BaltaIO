using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Application.Commands;

namespace PaymentContext.Tests.Commands
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTest
    {
        [TestMethod]
        public void ShouldReturnNameIsInvalid()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";

            command.Validate();
            Assert.IsFalse(command.IsValid);
        }
    }
}
