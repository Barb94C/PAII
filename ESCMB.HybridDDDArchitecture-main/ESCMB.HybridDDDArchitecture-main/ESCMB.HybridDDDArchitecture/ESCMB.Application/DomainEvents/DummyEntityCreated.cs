using Common.Application.Commands;
using static ESCMB.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ESCMB.Application.DomainEvents
{
    /// <summary>
    /// Ejemplo de un evento de dominio para la entidad Dummy.
    /// Todo evento de dominio debe heredar de <see cref="DomainEvent"/>
    /// </summary>
    internal sealed class DummyEntityCreated : DomainEvent
    {
        //Aqui se definen las propiedades compartidas en el evento
        public int DummyIdProperty { get; set; }
        public string? DummyPropertyTwo { get; set; }
        public DummyValues DummyPropertyThree { get; set; }
    }
}
