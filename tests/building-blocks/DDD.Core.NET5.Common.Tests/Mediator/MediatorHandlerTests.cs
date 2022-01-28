using Moq;
using Xunit;
using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using DDD.Core.NET5.Common.Mediator;
using DDD.Core.NET5.Common.Messages;
using DDD.Core.NET5.Common.Messages.Commands;

namespace DDD.Core.NET5.Common.Tests.Mediator
{
    public class MediatorHandlerTests
    {
        [Fact(DisplayName = "MediatorHandler publish event")]
        [Trait("MediatorHandler", "Mediator Tests")]
        public async Task MediatorHandler_Publish_Event()
        {
            //Arrange
            var @event = new ExternalEvent();
            var mediatorMock = new Mock<IMediator>();
            var mediatorHandler = new MediatorHandler(mediatorMock.Object);

            //Act
            await mediatorHandler.Publish<ExternalEvent, Guid>(@event);

            //Assert
            mediatorMock.Verify(x => x.Publish(@event, CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "MediatorHandler send query")]
        [Trait("MediatorHandler", "Mediator Tests")]
        public async Task MediatorHandler_Send_Query()
        {
            //Arrange
            var query = new ResultQuery();
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<Query<Result, Guid>>(), CancellationToken.None)).Returns(Task.FromResult(new Result()));
            var mediatorHandler = new MediatorHandler(mediatorMock.Object);

            //Act
            var result = await mediatorHandler.Query<ResultQuery, Result, Guid>(query);

            //Assert
            mediatorMock.Verify(x => x.Send(query, CancellationToken.None), Times.Once);
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "MediatorHandler send command")]
        [Trait("MediatorHandler", "Mediator Tests")]
        public async Task MediatorHandler_Send_Command()
        {
            //Arrange
            var command = new ActionCommand();
            var mediatorMock = new Mock<IMediator>();
            mediatorMock.Setup(x => x.Send(It.IsAny<CommandRequest<ValidationResult, Guid>>(), CancellationToken.None)).Returns(Task.FromResult(new ValidationResult()));
            var mediatorHandler = new MediatorHandler(mediatorMock.Object);

            //Act
            var result = await mediatorHandler.Send<ActionCommand, ValidationResult, Guid>(command);

            //Assert
            mediatorMock.Verify(x => x.Send(command, CancellationToken.None), Times.Once);
            Assert.NotNull(result);

        }
    }

    public class Result { }

    public class ExternalEvent : Event<Guid> { }

    public class ResultQuery : Query<Result, Guid> { }

    public class ActionCommand : CommandRequest<ValidationResult, Guid>
    {
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}