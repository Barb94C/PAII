using AutoMapper;
using ESCMB.Application.DataTransferObjects;
using ESCMB.Application.DomainEvents;
using ESCMB.Domain.Entities;

namespace ESCMB.Application.Mappings
{
    /// <summary>
    /// El mapeo entre objetos debe ir definido aqui
    /// </summary>
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<DummyEntity, DummyEntityCreated>().ReverseMap();
            CreateMap<DummyEntity, DummyEntityUpdated>().ReverseMap();
            CreateMap<DummyEntity, DummyEntityDto>().ReverseMap();
        }
    }
}
