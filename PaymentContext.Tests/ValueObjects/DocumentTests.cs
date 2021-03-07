using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var document = new Document("232323", EDocumentType.CNPJ);
            Assert.IsFalse(document.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var document = new Document("22871468000194", EDocumentType.CNPJ);
            Assert.IsTrue(document.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var document = new Document("232323", EDocumentType.CPF);
            Assert.IsFalse(document.IsValid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("84587451002")]
        [DataRow("95196967095")]
        [DataRow("35625823073")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var document = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(document.IsValid);
        }
    }
}
