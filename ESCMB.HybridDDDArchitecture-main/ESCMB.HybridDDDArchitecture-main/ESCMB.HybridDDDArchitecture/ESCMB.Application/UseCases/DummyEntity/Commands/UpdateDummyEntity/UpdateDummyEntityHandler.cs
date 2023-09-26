using Common.Application.Commands;
using ESCMB.Application.Common;
using ESCMB.Application.DomainEvents;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;
using MediatR;

namespace ESCMB.Application.UseCases.DummyEntity.Commands.UpdateDummyEntity
{
    internal sealed class UpdateDummyEntityHandler : IRequestCommandHandler<UpdateDummyEntityCommand>
    {
        private readonly IEventPublisher _publisher;
        private readonly IDummyEntityRepository _context;

        public UpdateDummyEntityHandler(IEventPublisher eventPublisher, IDummyEntityRepository dummyEntityRepository)
        {
            _publisher = eventPublisher ?? throw new ArgumentNullException(nameof(eventPublisher));
            _context = dummyEntityRepository ?? throw new ArgumentNullException(nameof(dummyEntityRepository));
        }

        public async Task<Unit> Handle(UpdateDummyEntityCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.DummyEntity entity = await _context.FindOneAsync(request.DummyIdProperty);

            if (entity is null) throw new EntityDoesNotExistException();

            entity.SetDummyPropertyTwo(request.DummyPropertyTwo);
            entity.SetDummyPropertyThree(request.DummyPropertyThree);

            try
            {
                _context.Update(entity);

                await _publisher.Publish(entity.To<DummyEntityUpdated>(), cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new BussinessException(Constants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }
        }
    }
}
