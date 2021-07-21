using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Application.Queries;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTest
    {
        private readonly IList<Student> _student;

        public StudentQueriesTest()
        {
            _student = new List<Student>();

            for (var i = 0; i <= 10; i++)
            {
                var name = new Name("Aluno", i.ToString());
                var document = new Document($"1111111111{i}", EDocumentType.CPF);
                var email = new Email($"email{i}@email.com.br");
                var student = new Student(name, document, email);
                _student.Add(student);
            }
        }

        [TestMethod]
        public void ShouldReturningNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("12345678911");
            var student = _student.AsQueryable().Where(exp).FirstOrDefault();
            Assert.IsNull(student);
        }

        [TestMethod]
        public void ShouldReturningStudentWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudentInfo("11111111111");
            var student = _student.AsQueryable().Where(exp).FirstOrDefault();
            Assert.IsNotNull(student);
        }
    }
}