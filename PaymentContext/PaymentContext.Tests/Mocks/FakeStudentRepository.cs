using System;
using System.Collections.Generic;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void Add(Student entity)
        {
            throw new NotImplementedException();
        }

        public void CreateSubscription(Student student)
        {
            throw new NotImplementedException();
        }

        public void Delete(Student entity)
        {
            throw new NotImplementedException();
        }

        public bool DocumentExists(string document)
        {
            if (document == "99999999999") return true;
            return false;
        }

        public bool EmailExists(string email)
        {
            if (email == "hello@balta.io") return true;
            return false;
        }

        public Student GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Student> ListAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
