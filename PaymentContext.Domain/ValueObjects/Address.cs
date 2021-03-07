using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }

        public string Number { get; private set; }

        public string Neighborhood { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string Country { get; private set; }

        public string ZipCode { get; private set; }

        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
        {
            this.Street = street;
            this.Number = number;
            this.Neighborhood = neighborhood;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.ZipCode = zipCode;

            AddNotifications(
                new Contract<Address>()
                .IsNotNullOrEmpty(street, "Address.Street", "Invalid street")
                .IsNotNullOrEmpty(number, "Address.Number", "Invalid number")
                .IsNotNullOrEmpty(neighborhood, "Address.Neighborhood", "Invalid neighborhood")
                .IsNotNullOrEmpty(city, "Address.City", "Invalid city")
                .IsNotNullOrEmpty(state, "Address.State", "Invalid state")
                .IsNotNullOrEmpty(country, "Address.Country", "Invalid country")
                .IsNotNullOrEmpty(zipCode, "Address.ZipCode", "Invalid zipCode")
            );
        }
    }
}