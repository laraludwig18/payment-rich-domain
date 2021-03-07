using Flunt.Validations;
using PaymentContext.Domain.Enums;
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
                .Requires()
                .IsNullOrEmpty(this.Street, "Address.Street", "Invalid street")
                .IsNullOrEmpty(this.Number, "Address.Number", "Invalid number")
                .IsNullOrEmpty(this.Neighborhood, "Address.Neighborhood", "Invalid neighborhood")
                .IsNullOrEmpty(this.City, "Address.City", "Invalid city")
                .IsNullOrEmpty(this.State, "Address.State", "Invalid state")
                .IsNullOrEmpty(this.Country, "Address.Country", "Invalid country")
                .IsNullOrEmpty(this.ZipCode, "Address.ZipCode", "Invalid zipCode")
            );
        }
    }
}