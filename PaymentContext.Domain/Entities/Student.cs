using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;

        public Name Name { get; private set; }

        public Document Document { get; private set; }

        public Email Email { get; private set; }

        public Address Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return this._subscriptions.ToArray(); } }

        public Student(Name name, Document document, Email email)
        {
            this.Name = name;
            this.Document = document;
            this.Email = email;
            this._subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = this._subscriptions.Any(sub => sub.Active == true);

            AddNotifications(
                new Contract<Student>()
                .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "You already have an active subscription")
                .AreNotEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "this subscription has no payments")
            );

            if (IsValid) this._subscriptions.Add(subscription);
        }
    }
}