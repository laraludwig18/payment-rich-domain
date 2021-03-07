using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Address { get; private set; }

        public Email(string address)
        {
            this.Address = address;

            AddNotifications(
                new Contract<Email>()
                .IsEmail(address, "Email.Address", "Invalid email")
            );
        }
    }
}