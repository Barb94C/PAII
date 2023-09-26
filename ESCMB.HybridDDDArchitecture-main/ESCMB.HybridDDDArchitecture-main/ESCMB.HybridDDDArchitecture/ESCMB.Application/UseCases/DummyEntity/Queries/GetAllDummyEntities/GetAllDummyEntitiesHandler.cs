using Common.Application.Commands;
using ESCMB.Application.Common;
using ESCMB.Application.DataTransferObjects;
using ESCMB.Application.Repositories.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.DummyEntity.Queries.GetAllDummyEntities
{
    internal sealed class GetAllDummyEntitiesHandler : IRequestQueryHandler<GetAllDummyEntitiesQuery, QueryResult<DummyEntityDto>>
    {
        private readonly IDummyEntityRepository _context;

        public GetAllDummyEntitiesHandler(IDummyEntityRepository context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<QueryResult<DummyEntityDto>> Handle(GetAllDummyEntitiesQuery request, CancellationToken cancellationToken)
        {
            IList<Domain.Entities.DummyEntity> entities = await _context.FindAllAsync();

            return new QueryResult<DummyEntityDto>(entities.To<DummyEntityDto>(), entities.Count, request.PageIndex, request.PageSize);
        }
    }
}
