using System;
using System.Collections.Generic;
using System.Linq;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Infra.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly List<Student> _students;

        public StudentRepository()
        {
            _students = new List<Student>();
        }

        public void Add(Student student)
        {
            _students.Add(student);
        }

        public void Delete(Student student)
        {
            _students.Remove(student);
        }

        public Student GetById(Guid id)
        {
            return _students.Find(s => s.Id == id);
        }

        public List<Student> ListAll()
        {
            return _students;
        }

        public void Update(Student entity)
        {
            var oldStudent = GetById(entity.Id);
            _students.Remove(oldStudent);
            _students.Add(entity);
        }


        public void CreateSubscription(Student student)
        {
            Update(student);
        }

        public bool DocumentExists(string document)
        {
            return _students.Any(s => s.Document.Number.Equals(document));
        }

        public bool EmailExists(string email)
        {
            return _students.Any(s => s.Email.Address.Equals(email));
        }
    }
}
