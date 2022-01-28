using Xunit;
using DDD.Core.NET5.Common.Specification;

namespace DDD.Core.NET5.Common.Tests.Specification
{
    public class GenericSpecificationTests
    {
        [Fact(DisplayName = "Generic specification IsSatisfiedby return true")]
        [Trait("GenericSpecifiication", "Specification Tests")]
        public void Generic_Specification_IsSatisfiedBy_Returns_True()
        {
            //Arrange
            var spec = new GenericSpecification<ClassA>(x => x.Property == true);
            var classA = new ClassA { Property = true };

            //Act
            var result = spec.IsSatisfiedBy(classA);

            //Assert
            Assert.True(result);
        }
    }

    public class ClassA
    {
        public bool Property { get; set; }
    }
}