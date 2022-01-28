using Xunit;
using System;
using System.Linq.Expressions;
using DDD.Core.NET5.Common.Specification;

namespace DDD.Core.NET5.Common.Tests.Specification
{
    public class SpecificationTests
    {
        [Fact(DisplayName = "Specification IsSatisfiedby class")]
        [Trait("Specification", "Specification Tests")]
        public void Specification_IsSatisfiedBy_Class()
        {
            //Arrange
            var spec = new ClassBSpecification1();
            var classB = new ClassB() { Property1 = true };

            //Act
            var result = spec.IsSatisfiedBy(classB);

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "AndSpecification is valid")]
        [Trait("Specification", "Specification Tests")]
        public void AndSpecification_Is_Valid()
        {
            //Arrange
            var classB = new ClassB() { Property1 = true, Property2 = false };

            //Act
            var result = new ClassBSpecification1().And(new ClassBSpecification2()).IsSatisfiedBy(classB);

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "OrSpecification is valid")]
        [Trait("Specification", "Specification Tests")]
        public void OrSpecification_Is_Valid()
        {
            //Arrange
            var classB = new ClassB() { Property1 = true, Property2 = true };

            //Act
            var result = new ClassBSpecification1().Or(new ClassBSpecification2()).IsSatisfiedBy(classB);

            //Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "NotSpecification is valid")]
        [Trait("Specification", "Specification Tests")]
        public void NotSpecification_Is_Valid()
        {
            //Arrange
            var classB = new ClassB() { Property1 = false };

            //Act
            var result = new ClassBSpecification1().Not().IsSatisfiedBy(classB);

            //Assert
            Assert.True(result);
        }
    }

    public class ClassBSpecification1 : Specification<ClassB>
    {
        public override Expression<Func<ClassB, bool>> ToExpression()
        {
            return value => value.Property1 == true;
        }
    }

    public class ClassBSpecification2 : Specification<ClassB>
    {
        public override Expression<Func<ClassB, bool>> ToExpression()
        {
            return value => value.Property2 == false;
        }
    }

    public class ClassB
    {
        public bool Property1 { get; set; }

        public bool Property2 { get; set; }
    }
}