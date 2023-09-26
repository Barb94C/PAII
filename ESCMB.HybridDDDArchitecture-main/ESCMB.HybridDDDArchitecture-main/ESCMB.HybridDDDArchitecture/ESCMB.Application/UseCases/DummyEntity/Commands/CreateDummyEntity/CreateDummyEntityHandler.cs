using Common.Application.Commands;
using ESCMB.Application.ApplicationServices;
using ESCMB.Application.Common;
using ESCMB.Application.DomainEvents;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;

namespace ESCMB.Application.UseCases.DummyEntity.Commands.CreateDummyEntity
{
    /// <summary>
    /// Ejemplo de handler que responde al comando <see cref="CreateDummyEntityCommand"/>
    /// y ejecuta el proceso para el caso de uso en cuestion.
    /// Todo handler debe implementar la interfaz <see cref="IRequestCommandHandler{TRequest, TResponse}"/>
    /// si devuelve una respuesta donde <c TRequest> es del tipo <see cref="CreateDummyEntityCommand"/>
    /// y <c TResponse> del tipo de dato definido para la respuesta
    /// /// </summary>
    internal sealed class CreateDummyEntityHandler : IRequestCommandHandler<CreateDummyEntityCommand, string>
    {
        private readonly IEventPublisher _publisher;
        private readonly IDummyEntityRepository _context;

        public CreateDummyEntityHandler(IEventPublisher eventPublisher, IDummyEntityRepository dummyEntityRepository)
        {
            _publisher = eventPublisher ?? throw new ArgumentNullException(nameof(eventPublisher));
            _context = dummyEntityRepository ?? throw new ArgumentNullException(nameof(dummyEntityRepository));
        }

        public async Task<string> Handle(CreateDummyEntityCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.DummyEntity entity = new Domain.Entities.DummyEntity(request.DummyPropertyTwo, request.DummyPropertyThree);

            if (!entity.IsValid) throw new InvalidEntityDataException(entity.ValidationErrors);

            if (_context.DummyEntityExist(entity.Id)) throw new EntityDoesExistException();

            try
            {
                int createdId = await _context.AddOneAsync(entity);

                await _publisher.Publish(entity.To<DummyEntityCreated>(), cancellationToken);

                return createdId.ToString();
            }
            catch (Exception ex)
            {
                throw new BussinessException(Constants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }
        }
    }
}
