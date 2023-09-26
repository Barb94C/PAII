using Common.Application.Commands;
using ESCMB.Application.DomainEvents;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;
using MediatR;

namespace ESCMB.Application.UseCases.DummyEntity.Commands.DeleteDummyEntity
{
    internal sealed class DeleteDummyEntityHandler : IRequestCommandHandler<DeleteDummyEntityCommand>
    {
        private readonly IEventPublisher _publisher;
        private readonly IDummyEntityRepository _context;

        public DeleteDummyEntityHandler(IEventPublisher eventPublisher, IDummyEntityRepository dummyEntityRepository)
        {
            _publisher = eventPublisher ?? throw new ArgumentNullException(nameof(eventPublisher));
            _context = dummyEntityRepository ?? throw new ArgumentNullException(nameof(dummyEntityRepository));
        }

        public Task<Unit> Handle(DeleteDummyEntityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _context.Remove(request.DummyIdProperty);

                _publisher.Publish(new DummyEntityDeleted(request.DummyIdProperty), cancellationToken);

                return Unit.Task;
            }
            catch (Exception ex)
            {
                throw new BussinessException(Constants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }
        }
    }
}
