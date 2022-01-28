using Moq;
using Xunit;
using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using DDD.Core.NET5.Common.Data;
using DDD.Core.NET5.Common.Handlers;
using DDD.Core.NET5.Common.Mediator;
using DDD.Core.NET5.Common.Messages.Commands;

namespace DDD.Core.NET5.Common.Tests.Handlers
{
    public class BaseCommandHandlerBehaviorTests
    {
        [Fact(DisplayName = "Create valid CommandHandlerBehavior")]
        [Trait("BaseCommandHandlerBehavior", "Handler Tests")]
        public void Create_Valid_CommandHandlerBehavior()
        {
            //Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>().Object;
            var mediatorHandlerMock = new Mock<IMediatorHandler>().Object;

            //Act
            var command = new CommandHandlerBehaviorImpl(unitOfWorkMock, mediatorHandlerMock);

            //Assert
            Assert.NotNull(command);
        }
    }

    public class CommandHandlerBehaviorImpl : BaseCommandHandlerBehavior<FakeCommandRequest, FakeCommandResponse, Guid>
    {
        public CommandHandlerBehaviorImpl(
            IUnitOfWork unitOfWork,
            IMediatorHandler mediatorHandler)
            : base(unitOfWork, mediatorHandler) { }

        public override Task<FakeCommandResponse> Handle(FakeCommandRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<FakeCommandResponse> next)
        {
            return next.Invoke();
        }
    }

    public class FakeCommandRequest : CommandRequest<FakeCommandResponse, Guid>
    {
        public void SetValidationResult()
        {
            ValidationResult = new ValidationResult();
        }
        
        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }

    public class FakeCommandResponse : CommandResponse<Guid>
    {
        public FakeCommandResponse(Guid aggregateId, object source, object command, string messageType, bool succeeded)
            : base(aggregateId, source, command, messageType, succeeded) { }
    }
}