using Common.Application.Commands;
using ESCMB.Application.Common;
using ESCMB.Application.DataTransferObjects;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;

namespace ESCMB.Application.UseCases.DummyEntity.Queries.GetDummyEntityBy
{
    internal sealed class GetDummyEntityByHandler : IRequestQueryHandler<GetDummyEntityByQuery, DummyEntityDto>
    {
        private readonly IDummyEntityRepository _context;

        public GetDummyEntityByHandler(IDummyEntityRepository context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<DummyEntityDto> Handle(GetDummyEntityByQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.DummyEntity entity = await _context.FindOneAsync(request.DummyIdProperty);

            if (entity is null) throw new EntityDoesNotExistException();

            return entity.To<DummyEntityDto>();
        }
    }
}
