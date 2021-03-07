using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
    {
        private IList<Payment> _payments;

        public DateTime CreatedDate { get; private set; }

        public DateTime LastUpdateDate { get; private set; }

        public DateTime? ExpireDate { get; private set; }

        public bool Active { get; private set; }

        public IReadOnlyCollection<Payment> Payments { get { return this._payments.ToArray(); } }

        public Subscription(DateTime? expireDate)
        {
            this.CreatedDate = DateTime.Now;
            this.LastUpdateDate = DateTime.Now;
            this.ExpireDate = expireDate;
            this.Active = true;
            this._payments = new List<Payment>();
        }

        public void AddPayment(Payment payment)
        {
            AddNotifications(
                new Contract<Subscription>()
                .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "Payment date must be in the future")
            );

            this._payments.Add(payment);
        }

        public void Activate()
        {
            this.Active = true;
            this.LastUpdateDate = DateTime.Now;
        }

        public void Inactivate()
        {
            this.Active = false;
            this.LastUpdateDate = DateTime.Now;
        }
    }
}