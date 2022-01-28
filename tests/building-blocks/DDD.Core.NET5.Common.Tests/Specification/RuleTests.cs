using Xunit;
using System;
using System.Linq.Expressions;
using DDD.Core.NET5.Common.Specification;
using DDD.Core.NET5.Common.Specification.Validation;

namespace DDD.Core.NET5.Common.Tests.Specification
{
    public class RuleTests
    {
        [Fact(DisplayName = "Constructing Rule")]
        [Trait("Rule", "Specification Tests")]
        public void Constructing_Rule()
        {
            //Arrange
            var spec = new ClassCSpecification();

            //Act
            var rule = new Rule<ClassC>(spec, "Property can't be false");

            //Assert
            Assert.NotNull(rule);
        }

        [Fact(DisplayName = "ErrorMessage not null or empty")]
        [Trait("Rule", "Specification Tests")]
        public void ErrorMessage_Not_Null_Or_Empty()
        {
            //Arrange
            var spec = new ClassCSpecification();

            //Act
            var rule = new Rule<ClassC>(spec, "Property can't be false");

            //Assert
            Assert.NotNull(rule.ErrorMessage);
            Assert.NotEmpty(rule.ErrorMessage);
        }

        [Fact(DisplayName = "Validate method returns valid value")]
        [Trait("Rule", "Specification Tests")]
        public void Validate_Method_Returns_Valid_Value()
        {
            //Arrange
            var spec = new ClassCSpecification();
            var classC = new ClassC { Property1 = true };
            var rule = new Rule<ClassC>(spec, "Property can't be false");

            //Act
            var result = rule.Validate(classC);

            //Assert
            Assert.True(result);
        }
    }

    public class ClassC
    {
        public bool Property1 { get; set; }
    }

    public class ClassCSpecification : Specification<ClassC>
    {
        public override Expression<Func<ClassC, bool>> ToExpression()
        {
            return value => value.Property1 == true;
        }
    }
}