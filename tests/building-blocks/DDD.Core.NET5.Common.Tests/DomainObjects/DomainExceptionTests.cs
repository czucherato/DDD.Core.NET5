using Xunit;
using System;
using System.Runtime.Serialization;
using DDD.Core.NET5.Common.DomainObjects;

namespace DDD.Core.NET5.Common.Tests.DomainObjects
{
    public class DomainExceptionTests
    {
        [Fact(DisplayName = "Parameterless constructor expects throwing exception")]
        [Trait("DomainException", "Domain Object Tests")]
        public void Parameterless_Constructor_Expects_Throwing_Exception()
        {
            //Arrage & Act & Assert
            Assert.ThrowsAsync<DomainException>(() => throw new DomainException()).GetAwaiter().GetResult();
        }

        [Fact(DisplayName = "Passing message expects throwing exception")]
        [Trait("DomainException", "Domain Object Tests")]
        public void Passing_Message_Expects_Throwing_Exception()
        {
            //Arrage & Act & Assert
            Assert.ThrowsAsync<DomainException>(() => throw new DomainException("Exception message")).GetAwaiter().GetResult();
        }

        [Fact(DisplayName = "Passing InnerException Expects throwing exception")]
        [Trait("DomainException", "Domain Object Tests")]
        public void Passing_InnerException_Expects_Throwing_Exception()
        {
            //Arrage
            var exception = new Exception("Exception message");

            //Act & Assert
            Assert.ThrowsAsync<DomainException>(() => throw new DomainException(exception.Message, exception)).GetAwaiter().GetResult();
        }

        [Fact(DisplayName = "Calling protected constructor")]
        [Trait("DomainException", "Domain Object Tests")]
        public void Calling_Protected_Constructor()
        {
            //Arrange
            SerializationInfo info = new(typeof(ExtendedDomainException), new FormatterConverter());
            info.AddValue("Message", string.Empty);
            info.AddValue("InnerException", new ArgumentException());
            info.AddValue("HelpURL", string.Empty);
            info.AddValue("StackTraceString", string.Empty);
            info.AddValue("RemoteStackTraceString", string.Empty);
            info.AddValue("RemoteStackIndex", 0);
            info.AddValue("ExceptionMethod", string.Empty);
            info.AddValue("HResult", 1);
            info.AddValue("Source", string.Empty);
            StreamingContext context = new();

            //Act
            var exception = new ExtendedDomainException(info, context);

            //Assert
            Assert.NotNull(exception);
        }
    }

    public class ExtendedDomainException : DomainException
    {
        public ExtendedDomainException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}