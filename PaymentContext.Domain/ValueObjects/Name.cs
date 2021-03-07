using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Name(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            AddNotifications(
                new Contract<Name>()
                .Requires()
                .IsNullOrEmpty(this.FirstName, "Name.FirstName", "Invalid first name")
                .IsNullOrEmpty(this.LastName, "Name.LastName", "Invalid last name")
            );
        }
    }
}