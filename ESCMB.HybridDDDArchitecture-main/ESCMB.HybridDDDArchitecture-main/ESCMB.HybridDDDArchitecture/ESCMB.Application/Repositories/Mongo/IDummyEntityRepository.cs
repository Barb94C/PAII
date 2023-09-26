using Common.Application.Repositories.MongoDb;
using ESCMB.Domain.Entities;

namespace ESCMB.Application.Repositories.Mongo
{
    /// <summary>
    /// Ejemplo de interface de un repositorio Mongo de entidad Dummy
    /// Todo repositorio debe implementar la interfaz <see cref="IRepository{T}"/>
    /// donde <c T> es la entidad de dominio que queremos persistir
    /// </summary>
    public interface IDummyEntityRepository : IRepository<DummyEntity>
    {
        //Aqui se definen propiedades y metodos Custom.
    }
}
