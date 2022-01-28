using Xunit;
using System.Collections.Generic;
using DDD.Core.NET5.Common.DomainObjects;

namespace DDD.Core.NET5.Common.Tests.DomainObjects
{
    public class ValueObjectTests
    {
        [Fact(DisplayName = "ValueObject is not equals to")]
        [Trait("ValueObject", "Domain Object Tests")]
        public void ValueObject_IsNot_Equals_To()
        {
            //Arrange
            var valueA = new ValueObjectA("Some Value A", 1);
            var valueB = new ValueObjectB("Some Value B", 2);

            //Act & Assert
            Assert.False(valueA.Equals(valueB));
        }

        [Fact(DisplayName = "ValueObject is equals to")]
        [Trait("ValueObject", "Domain Object Tests")]
        public void ValueObject_Is_Equals_To()
        {
            //Arrange
            var valueA = new ValueObjectA("Some Value A", 1);
            var valueB = valueA;

            //Act & Assert
            Assert.True(valueA.Equals(valueB));
        }

        [Fact(DisplayName = "ValueObject GetHashCode is not equal to zero")]
        [Trait("ValueObject", "Domain Object Tests")]
        public void ValueObject_GetHashCode_Is_Not_Equal_To_Zero()
        {
            //Arrange
            var valueA = new ValueObjectA("Some Value A", 1);

            //Act & Assert
            Assert.True(valueA.GetHashCode() != 0);
        }

        [Fact(DisplayName = "Equals returns false when compare ValueObject is null")]
        [Trait("ValueObject", "Domain Object Tests")]
        public void Equals_Returns_False_When_Compare_ValueObject_Is_Null()
        {
            //Arrange
            var valueA = new ValueObjectA("Some Value A", 1);

            //Act & Assert
            Assert.False(valueA.Equals(null));
        }

        [Fact(DisplayName = "ValueObject GetHashCode suppress arithmetic overflow")]
        [Trait("ValueObject", "Domain Object Tests")]
        public void ValueObject_GetHashCode_Suppress_Arithmetic_Overflow()
        {
            //Arrange
            var valueA = new ValueObjectA("Some Value A", int.MaxValue);

            //Act
            var exception = Record.Exception(() => valueA.GetHashCode());

            //Assert
            Assert.Null(exception);
        }
    }

    public class ValueObjectA : ValueObject
    {
        public ValueObjectA(string propertOne, int propertTwo)
        {
            PropertOne = propertOne;
            PropertTwo = propertTwo;
        }

        public string PropertOne { get; private set; }

        public int PropertTwo { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PropertOne;
            yield return PropertTwo;
        }
    }

    public class ValueObjectB : ValueObject
    {
        public ValueObjectB(string propertOne, int propertTwo)
        {
            PropertOne = propertOne;
            PropertTwo = propertTwo;
        }

        public string PropertOne { get; private set; }

        public int PropertTwo { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PropertOne;
            yield return PropertTwo;
        }
    }
}