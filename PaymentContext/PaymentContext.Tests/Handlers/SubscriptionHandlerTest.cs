using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Application.Commands;
using PaymentContext.Application.Handlers;
using PaymentContext.Domain.Enums;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTest
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentsExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailServices());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Bruce";
            command.LastName = "Wayne";
            command.Document = "99999999999";
            command.Email = "hello@balta.io2";

            command.BarCode = "12345678963";
            command.BoletoNumber = "1234567896";

            command.PaymentNumber = "124123";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Wayne CORP";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "batman@dc.com";

            command.Street = "Rua do Batman";
            command.Number = "123";
            command.Neighborhood = "Bairro";
            command.City = "Gothan";
            command.State = "SP";
            command.Country = "Brasil";
            command.ZipCode = "12211232";

            handler.Handler(command);

            Assert.AreEqual(1, handler.Notifications.Count);
            Assert.AreEqual("Document", handler.Notifications.First().Key);
            Assert.AreEqual("Este documento já está em uso", handler.Notifications.First().Message);
            Assert.IsFalse(handler.IsValid);
        }
    }
}
