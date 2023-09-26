using Common.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ESCMB.Domain.Enums;

namespace ESCMB.Application.DomainEvents
{
    internal sealed class DummyEntityUpdated : DomainEvent
    {
        public int DummyIdProperty { get; set; }
        public string? DummyPropertyTwo { get; set; }
        public DummyValues DummyPropertyThree { get; set; }
    }
}
