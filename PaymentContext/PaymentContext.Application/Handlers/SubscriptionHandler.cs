using System;
using Flunt.Notifications;
using PaymentContext.Application.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Application.Handlers
{
    public class SubscriptionHandler :
        Notifiable<Notification>,
        IHandler<CreateBoletoSubscriptionCommand>,
        IHandler<CreateCreditCardSubscriptionCommand>,
        IHandler<CreatePaypalSubscriptionCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEmailServices _emailServices;

        public SubscriptionHandler(IStudentRepository studentRepository, IEmailServices emailServices)
        {
            _studentRepository = studentRepository;
            _emailServices = emailServices;
        }

        public ICommandResult Handler(CreateBoletoSubscriptionCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel realizar seu cadastro");
            }

            if (_studentRepository.DocumentExists(command.Document))
                AddNotification("Document", "Este documento já está em uso");

            if (_studentRepository.EmailExists(command.Email))
                AddNotification("Email", "Este e-mail já está em uso");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(
                command.BarCode, command.BoletoNumber, command.PaidDate, command.ExpireDate, command.Total,
                command.TotalPaid, command.Payer, document, address, email
            );

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, student, subscription, payment);

            if (!this.IsValid)
                return new CommandResult(false, "Não foi possivel realizar seu cadastro");

            _studentRepository.CreateSubscription(student);

            _emailServices.Send(student.Name.ToString(), student.Email.Address, "Bem-Vindo", "Sua assinatura foi criada");

            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handler(CreateCreditCardSubscriptionCommand command)
        {
            throw new System.NotImplementedException();
        }

        public ICommandResult Handler(CreatePaypalSubscriptionCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
