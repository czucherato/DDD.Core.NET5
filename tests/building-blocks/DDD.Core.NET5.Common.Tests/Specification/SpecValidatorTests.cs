using Xunit;
using System;
using System.Linq.Expressions;
using DDD.Core.NET5.Common.Specification;
using DDD.Core.NET5.Common.Specification.Validation;

namespace DDD.Core.NET5.Common.Tests.Specification
{
    public class SpecValidatorTests
    {
        [Fact(DisplayName = "Adding rule")]
        [Trait("SpecValidator", "Specification Tests")]
        public void Adding_Rule()
        {
            //Arrange
            var specValidator = new SpecValidator<ClassD>();
            var spec = new ClassDCSpecification();
            var rule = new Rule<ClassD>(spec, "Property can't be false");

            //Act & Assert
            specValidator.Add("Rule 1", rule);
        }

        [Fact(DisplayName = "Removing rule")]
        [Trait("SpecValidator", "Specification Tests")]
        public void Removing_Rule()
        {
            //Arrange
            var specValidator = new SpecValidator<ClassD>();
            var spec = new ClassDCSpecification();
            var rule = new Rule<ClassD>(spec, "Property can't be false");
            specValidator.Add("Rule 1", rule);

            //Act & Assert
            specValidator.Remove("Rule 1");
        }

        [Fact(DisplayName = "Getting rule")]
        [Trait("SpecValidator", "Specification Tests")]
        public void Getting_Rule()
        {
            //Arrange
            var specValidator = new SpecValidator<ClassD>();
            var spec = new ClassDCSpecification();
            var rule = new Rule<ClassD>(spec, "Property can't be false");
            specValidator.Add("Rule 1", rule);

            //Act
            var result = specValidator.GetRule("Rule 1");

            //Assert
            Assert.Equal(rule, result);
        }

        [Fact(DisplayName = "Validate without spec errors")]
        [Trait("SpecValidator", "Specification Tests")]
        public void Validate_Without_Spec_Errors()
        {
            //Arrange
            var classD = new ClassD { Property1 = true };
            var specValidator = new SpecValidator<ClassD>();
            var spec = new ClassDCSpecification();
            var rule = new Rule<ClassD>(spec, "Property can't be false");
            specValidator.Add("Rule 1", rule);

            //Act
            var validationResult = specValidator.Validate(classD);

            //Assert
            Assert.True(validationResult.IsValid);
        }

        [Fact(DisplayName = "Vaidate with spec errors")]
        [Trait("SpecValidator", "Specification Tests")]
        public void Validate_With_Spec_Errors()
        {
            //Arrange
            var classD = new ClassD { Property1 = false };
            var specValidator = new SpecValidator<ClassD>();
            var spec = new ClassDCSpecification();
            var rule = new Rule<ClassD>(spec, "Property can't be false");
            specValidator.Add("Rule 1", rule);

            //Act
            var validationResult = specValidator.Validate(classD);

            //Assert
            Assert.False(validationResult.IsValid);
        }
    }

    public class ClassD
    {
        public bool Property1 { get; set; }
    }

    public class ClassDCSpecification : Specification<ClassD>
    {
        public override Expression<Func<ClassD, bool>> ToExpression()
        {
            return value => value.Property1 == true;
        }
    }
}