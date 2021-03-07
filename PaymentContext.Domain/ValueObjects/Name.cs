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
                .IsNotNullOrEmpty(firstName, "Name.FirstName", "Invalid first name")
                .IsNotNullOrEmpty(lastName, "Name.LastName", "Invalid last name")
            );
        }
    }
}