using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddSubscription()
        {
            // var subscription = new Subscription(null);
            // var document = new Document("02551468094", EDocumentType.CPF);
            var name = new Name("Lara", "Ludwig");
            // var email = new Email("laraludwig18@gmail.com");
            // var address = new Address("", "", "", "", "", "", "");
            // var payment = new PayPalPayment("2323", DateTime.Now, DateTime.Now, 5000, 5000, document, "Lara Ludwig", address, email);

            // var student = new Student(name, document, email);
            // student.AddSubscription(subscription);
        }
    }
}
