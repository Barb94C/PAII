using Common.Application.Commands;
using System.ComponentModel.DataAnnotations;
using static ESCMB.Domain.Enums;

namespace ESCMB.Application.UseCases.DummyEntity.Commands.UpdateDummyEntity
{
    public class UpdateDummyEntityCommand : IRequestCommand
    {
        [Required]
        public int DummyIdProperty { get; set; }
        [Required]
        public string? DummyPropertyTwo { get; set; }
        public DummyValues DummyPropertyThree { get; set; }

        public UpdateDummyEntityCommand()
        {
        }
    }
}
