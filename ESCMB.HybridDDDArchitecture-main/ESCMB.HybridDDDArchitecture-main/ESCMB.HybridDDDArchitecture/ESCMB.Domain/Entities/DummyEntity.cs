using Common.Domain.Entities;
using ESCMB.Domain.Validators;
using static ESCMB.Domain.Enums;

namespace ESCMB.Domain.Entities
{
    /// <summary>
    /// Ejemplo de entidad de dominio Dummy
    /// Toda entidad de dominio debe heredar de <see cref="DomainEntity{T}"/>
    /// Donde T es del tipo <see cref="Common.Domain.Validators.EntityValidator{U}{"/>
    /// </summary>
    public class DummyEntity : DomainEntity<DummyEntityValidator>
    {
        public int Id { get; private set; }
        public string? DummyPropertyTwo { get; private set; }
        public DummyValues DummyPropertyThree { get; private set; }

        public DummyEntity()
        {
        }

        public DummyEntity(string? dummyPropertyTwo, DummyValues dummyPropertyThree)
        {
            SetDummyPropertyTwo(dummyPropertyTwo);
            DummyPropertyThree = dummyPropertyThree;
        }

        public DummyEntity(int dummyIdProperty, string? dummyPropertyTwo, DummyValues dummyPropertyThree)
        {
            Id = dummyIdProperty;
            SetDummyPropertyTwo(dummyPropertyTwo);
            DummyPropertyThree = dummyPropertyThree;
        }

        public void SetDummyPropertyTwo(string? value)
        {
            DummyPropertyTwo = value ?? throw new ArgumentNullException(nameof(value));
        }

        public void SetDummyPropertyThree(DummyValues value)
        {
            DummyPropertyThree = value;
        }
    }
}
