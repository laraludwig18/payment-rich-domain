using System;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        public string Number { get; private set; }

        public DateTime PaidDate { get; private set; }

        public DateTime ExpireDate { get; private set; }

        public decimal Total { get; private set; }

        public decimal TotalPaid { get; private set; }

        public Document Document { get; private set; }

        public string Payer { get; private set; }

        public Address Address { get; private set; }

        public Email Email { get; private set; }

        protected Payment(
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            Document document,
            string payer,
            Address address,
            Email email)
        {
            this.Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            this.PaidDate = paidDate;
            this.ExpireDate = expireDate;
            this.Total = total;
            this.TotalPaid = totalPaid;
            this.Document = document;
            this.Payer = payer;
            this.Address = address;
            this.Email = email;
            
            AddNotifications(
                new Contract<Payment>()
                .IsLowerOrEqualsThan(0, total, "Payment.Total", "Total must be greater than 0")
                .IsGreaterOrEqualsThan(total, totalPaid, "Payment.TotalPaid", "Paid amount is less than payment value")
            );
        }
    }
}