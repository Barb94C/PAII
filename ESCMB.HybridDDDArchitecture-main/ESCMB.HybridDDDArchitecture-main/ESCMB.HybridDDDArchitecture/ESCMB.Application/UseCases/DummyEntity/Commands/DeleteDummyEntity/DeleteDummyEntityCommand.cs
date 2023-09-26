using Common.Application.Commands;
using System.ComponentModel.DataAnnotations;

namespace ESCMB.Application.UseCases.DummyEntity.Commands.DeleteDummyEntity
{
    public class DeleteDummyEntityCommand : IRequestCommand
    {
        [Required]
        public int DummyIdProperty { get; set; }

        public DeleteDummyEntityCommand()
        {
        }
    }
}
