using Xunit;
using System;
using DDD.Core.NET5.Common.DomainObjects;

namespace DDD.Core.NET5.Common.Tests.DomainObjects
{
    public class EntityTests
    {
        [Fact(DisplayName = "Entity is not equals to")]
        [Trait("Entity", "Domain Object Tests")]
        public void Entity_IsNot_Equals_To()
        {
            //Arrange
            var entityA = new EntityA();
            var entityB = new EntityB();

            //Act & Assert
            Assert.False(entityA.Equals(entityB));
        }

        [Fact(DisplayName = "Entity GetHashCode is not equal to zero")]
        [Trait("Entity", "Domain Object Tests")]
        public void Entity_GetHashCode_Is_Not_Equal_To_Zero()
        {
            //Arrange 
            var entityA = new EntityA();

            //Act & Assert
            Assert.True(entityA.GetHashCode() != 0);
        }

        [Fact(DisplayName = "Entity ToString is no empty")]
        [Trait("Entity", "Domain Object Tests")]
        public void Entity_ToString_Is_Not_Empty()
        {
            //Arrange 
            var entityA = new EntityA();

            //Act & Assert
            Assert.False(string.IsNullOrEmpty(entityA.ToString()));
        }

        [Fact(DisplayName = "Entity is not equals to")]
        [Trait("Entity", "Domain Object Tests")]
        public void Entity_Is_Equals_To()
        {
            //Arrange
            var entityA = new EntityA();
            var entityAClone = entityA;

            //Act & Assert
            Assert.True(entityA.Equals(entityAClone));
        }

        [Fact(DisplayName = "Equals returns false when compare entity is null")]
        [Trait("Entity", "Domain Object Tests")]
        public void Equals_Returns_False_When_Compare_Entity_Is_Null()
        {
            //Arrange 
            var entityA = new EntityA();

            //Act & Assert
            Assert.False(entityA.Equals(null));
        }

        [Fact(DisplayName = "Equals returns true when compare entity has the same reference")]
        [Trait("Entity", "Domain Object Tests")]
        public void Equals_Returns_True_When_Compare_Entity_Has_The_Same_Reference()
        {
            //Arrange 
            var entityA = new EntityA();
            var entityAClone = entityA;

            //Act & Assert
            Assert.True(entityA.Equals(entityAClone));
        }
    }

    public class EntityA : Entity<Guid>
    {
        public EntityA()
        {
            Id = Guid.NewGuid();
        }
    }

    public class EntityB : Entity<Guid>
    {
        public EntityB()
        {
            Id = Guid.NewGuid();
        }
    }
}