using Common.Domain.Validators;
using ESCMB.Domain.Entities;
using FluentValidation;

namespace ESCMB.Domain.Validators
{
    /// <summary>
    /// Ejemplo de validador de entidad Dummy
    /// Todo validador de entidad de dominio debe heredar de <see cref="EntityValidator{T}{T}"/>
    /// Donde T es del tipo <see cref="Common.Domain.Entities.DomainEntity{T}"/>
    /// </summary>
    public class DummyEntityValidator : EntityValidator<DummyEntity>
    {
        public DummyEntityValidator()
        {
            //Las reglas de negocio deben ir definidas aca
            RuleFor(x => x.DummyPropertyTwo).NotNull().NotEmpty().WithMessage(Constants.NOTNULL_OR_EMPTY);
        }
    }
}
