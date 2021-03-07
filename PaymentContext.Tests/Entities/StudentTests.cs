using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;

        private readonly Document _document;

        private readonly Email _email;

        private readonly Address _address;

        private readonly Student _student;

        public StudentTests()
        {
            this._name = new Name("John", "Doee");
            this._document = new Document("84587451002", EDocumentType.CPF);
            this._email = new Email("joedoe@gmail.com");
            this._student = new Student(this._name, this._document, this._email);
            this._address = new Address("Rua 1", "1234", "Bairro Legal", "Gotham", "SP", "BR", "13400000");
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var subscription = new Subscription(null);
            var payment = new PayPalPayment(
                "2323", 
                DateTime.Now, 
                DateTime.Now.AddDays(5), 
                5000, 
                5000, 
                this._document, 
                "Joe Doe Corp", 
                this._address, 
                this._email
            );
            subscription.AddPayment(payment);
            this._student.AddSubscription(subscription);
            this._student.AddSubscription(subscription);

            Assert.IsFalse(this._student.IsValid);
            Assert.AreEqual(this._student.Notifications.Count, 1);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
        {
            var subscription = new Subscription(null);
            this._student.AddSubscription(subscription);

            Assert.IsFalse(this._student.IsValid);
            Assert.AreEqual(this._student.Notifications.Count, 1);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var subscription = new Subscription(null);
            var payment = new PayPalPayment(
                "2323", 
                DateTime.Now, 
                DateTime.Now.AddDays(5), 
                5000, 
                5000, 
                this._document, 
                "Joe Doe Corp", 
                this._address, 
                this._email
            );
            subscription.AddPayment(payment);
            this._student.AddSubscription(subscription);

            Assert.IsTrue(this._student.IsValid);
        }
    }
}
