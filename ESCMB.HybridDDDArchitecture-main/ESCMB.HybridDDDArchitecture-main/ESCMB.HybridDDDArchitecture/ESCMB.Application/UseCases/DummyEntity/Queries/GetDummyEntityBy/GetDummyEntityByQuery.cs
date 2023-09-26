using Common.Application.Commands;
using ESCMB.Application.DataTransferObjects;
using System.ComponentModel.DataAnnotations;

namespace ESCMB.Application.UseCases.DummyEntity.Queries.GetDummyEntityBy
{
    public class GetDummyEntityByQuery : IRequestQuery<DummyEntityDto>
    {
        [Required]
        public int DummyIdProperty { get; set; }

        public GetDummyEntityByQuery()
        {
        }
    }
}
